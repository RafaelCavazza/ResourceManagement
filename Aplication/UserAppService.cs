using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplication.Interfaces;
using Aplication.Services.Email.Enums;
using Aplication.Services.Email.Interfaces;
using Aplication.Services.Email.Templates;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Aplication
{
    public class UserAppService  : AppServiceBase<User>, IUserAppService
    {
        public readonly IUserService _userService;
        public readonly IEmployeeService _employeeService;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;


        public UserAppService(IUserService userService, 
                              IEmployeeService employeeService,
                              UserManager<User> userManager,
                              IEmailSender emailSender
                              ) : base(userService)
        {
            _userService = userService;
            _employeeService = employeeService;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<IdentityResult> Register(Guid employeeId)
        {
            var user = InstantiateUserFromEmployee(employeeId);
            var result = await _userManager.CreateAsync(user, User.GenerateRandomPassword());

            if (result.Succeeded)
                SendResetPasswordEmail(user, await _userManager.GeneratePasswordResetTokenAsync(user));

            return result;
        }

        public User InstantiateUserFromEmployee(Guid employeeId)
        {
            var employee = _employeeService.GetById(employeeId);
            return new User
            {
                UserName = employee.Name.Replace(" ", ""),
                Email = employee.Email,
                EmployeeId = employeeId,
                Active = true
            };
        }

        public async void ForgotPassword(Guid userId)
        {
            var user = _userService.GetById(userId);
            var password = User.GenerateRandomPassword();
            var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            SendResetPasswordEmail(user, resetPasswordToken);
        }

        private void SendResetPasswordEmail(User user, string resetPasswordToken)
        {
            var body = EmailTemplate.GetTemplate("ResetPassword", ResetPasswordEmailParameters(user, resetPasswordToken) );
            var to = new List<string>() {user.Email};
            var subject =  "Email Para Redefinição de Senha";
            var from = "donotreply@resourcemanager.com";
            _emailSender.Send(from, to, subject, body, EmailContentType.Html); 
        }        

        private Dictionary<string,string> ResetPasswordEmailParameters(User user, string resetPasswordToken)
        {
            var employee = _employeeService.GetById(user.EmployeeId);
            var encodedToken = System.Net.WebUtility.UrlEncode(resetPasswordToken);
            var aplicationUrl = "http://localhost:5000/Users/ResetPassword?userId=" + user.Id +"&resetPasswordToken=" + encodedToken;

            return new Dictionary<string,string>(){
                {"UserName", employee.Name},
                {"Link", aplicationUrl}
            };
        }
    }
}
