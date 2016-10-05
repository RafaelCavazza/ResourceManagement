using Aplication;
using Aplication.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.StartupExtensions
{
    public static class DiExtensions
    {
        public static void DomainDi(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
            services.AddScoped(typeof(IBranchService), typeof(BranchService));
        }

        public static void InfraDi(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            services.AddScoped(typeof(IBranchRepository), typeof(BranchRepository));
        }

        public static void AplicationDi(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped(typeof(IEmployeeAppService), typeof(EmployeeAppService));
            services.AddScoped(typeof(IBranchAppService), typeof(BranchAppService));
        }
    }
}
