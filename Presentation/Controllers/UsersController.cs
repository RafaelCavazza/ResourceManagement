using System.Linq;
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
        //private readonly IEmailSender _emailSender;
        //private readonly ISmsSender _smsSender;
        //private static bool _databaseChecked;
        private readonly ILogger _logger;

        public UsersController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            //IEmailSender emailSender,
            //ISmsSender smsSender,
            ILoggerFactory loggerFactory,
            IEmployeeAppService employeeAppService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;
            //_smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<UsersController>();
            _employeeAppService = employeeAppService;
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            var model = new CreateUserViewModel();
            var employees = _employeeAppService.GetAll().Where(p=> p.Active).ToList();
            model.Employee = new SelectList(employees,"Id", "Name"); 
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeAppService.GetById(model.EmployeeId);
                @ViewBag.UserEmail = employee.Email;

                var user = new User 
                { 
                    UserName = employee.Name.Replace(" ",""), 
                    Email = employee.Email, 
                    EmployeeId=model.EmployeeId 
                };

                var password = Domain.Entities.User.GenerateRandomPassword();
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    //    "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                    _logger.LogInformation(3, "User created a new account with password.");
                    return View("Success");
                }
                //AddErrors(result); //Trabalhar com erros depois
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
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
