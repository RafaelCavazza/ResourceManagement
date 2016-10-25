using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Aplication.Interfaces
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        Task<IdentityResult> Register(Guid employeeId);
        void ForgotPassword(Guid userId);
    }
}