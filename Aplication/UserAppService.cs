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
            var employee = _employeeService.GetById(employeeId);
            var user = new User
            {
                UserName = employee.Name.Replace(" ", ""),
                Email = employee.Email,
                EmployeeId = employeeId,
                Active = true
            };

            var password = User.GenerateRandomPassword();
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                SendRegisterEmail(user.Id, code);
            }

            return result;
        }

        private void SendRegisterEmail(Guid userId, string confirmationToken)
        {
            var user = _userService.GetById(userId);
            var employee = _employeeService.GetById(user.EmployeeId);
            var aplicationUrl = "http://localhost:5000/User/Confirm?token=" + confirmationToken;

            var parameters = new Dictionary<string,string>();
            parameters.Add("UserName", employee.Name);
            parameters.Add("Link", aplicationUrl);

            var body = EmailTemplate.GetTemplate("Register", parameters );
            var to = new List<string>() {user.Email};
            var subject =  "Bem vindo ao Resource Manager";
            var from = "donotreply@resourcemanager.com";
            _emailSender.Send(from, to, subject, body, EmailContentType.Html); 
        }
    }
}
