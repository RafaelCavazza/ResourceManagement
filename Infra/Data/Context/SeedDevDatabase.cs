using System;
using Aplication.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data.Context
{
    //TODO: Verificar a melhor maneira de semear o banco em Desenvolvimento

    public class SeedDevDatabase
    {
        private IUserAppService _userAppService;

        public SeedDevDatabase()
        {
            
        }

        public void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataBaseContext>();
                if(context.Database.EnsureCreated())           
                {
                    var branchId = CreateDevBranc(context);
                    var employeeId  = CreateDevEmployee(context, branchId);
                    _userAppService.Register(employeeId);
                }
            }
        }

        private Guid CreateDevBranc(DataBaseContext dbContext)
        {
            var devBranch = new Branch
            {
                Id =  Guid.NewGuid(),
                Name = "Empresa de Desenvolvimento",
                Cnpj = "17.884.050/0001-81"
            };

            dbContext.Branch.Add(devBranch);
            dbContext.SaveChanges();

            return devBranch.Id;
        }

        private Guid CreateDevEmployee(DataBaseContext dbContext, Guid branchId)
        {
            var devEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Desenvolvedor",
                Cpf = "",
                Identifier = "",
                AdmissionDate = DateTime.Now,
                Email = "desenvolvedor@testeInterno.com.br",
                Active = true,
                BranchId = branchId
            };

            dbContext.Employee.Add(devEmployee);
            dbContext.SaveChanges();

            return devEmployee.Id;
        }
    }
}