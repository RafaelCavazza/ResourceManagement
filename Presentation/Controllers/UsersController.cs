using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplication.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Presentation.ViewModels.User;

namespace Presentation.Controllers
{
    public class UsersController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IUserAppService _userAppService;
        private readonly ILogger _logger;

        public UsersController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILoggerFactory loggerFactory,
            IEmployeeAppService employeeAppService,
            IUserAppService userAppService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<UsersController>();
            _employeeAppService = employeeAppService;
            _userAppService = userAppService;
        }


        [Authorize]
        public IActionResult Index(int page = 1)
        {
            var users = _userAppService.GetPaged(page);
            return View(users);
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            var model = new CreateUserViewModel();
            var employees = _employeeAppService.GetAllWithoutUser().Where(p => p.Active).ToList();
            model.Employee = new SelectList(employees, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return Redirect("Create");

            var employee = _employeeAppService.GetById(model.EmployeeId.Value);
            @ViewBag.UserEmail = employee.Email;

            var result = await _userAppService.Register(employee.Id);

            if(result.Succeeded)
                return View("Success");
            else
                return Redirect("Create");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            _userAppService.ForgotPassword(user.Id);
            return Redirect("Login");
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(Guid userId, string resetPasswordToken)
        {
            var user = _userAppService.GetById(userId);
            if(user == null)
                return RedirectToAction("Login");

            return View(new ResetPasswordUserViewModel{ ResetPasswordToken = WebUtility.UrlEncode(resetPasswordToken) });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordUserViewModel model)
        {
            if(!ModelState.IsValid || model.Password != model.ConfirmPassword)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _userManager.ResetPasswordAsync(user,model.ResetPasswordToken, model.Password);
            if(result.Succeeded)
                return RedirectToAction("Login");
            else
            {
                foreach(var erro in result.Errors)
                    ModelState.AddModelError("CustomErros", erro.Description);                
                return View(model);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                //}
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return RedirectToAction("Index", "Home");
        }
    }
}
