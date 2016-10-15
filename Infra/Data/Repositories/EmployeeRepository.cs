using System;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public Tuple<bool, string> IsDuplicatedEmployee(Employee employee)
        {
            var _employee = dbContext.Employee.FirstOrDefault( p=> 
                (
                    p.Identifier == employee.Identifier ||
                    p.Cpf == employee.Cpf ||
                    p.Email == employee.Email
                )
                && p.Id != employee.Id
            );

            if(_employee == null)
                return Tuple.Create(false,"");
            else if(_employee.Cpf == employee.Cpf)
                return Tuple.Create(true,"Já existe um funcionário com o Cpf: " + _employee.Cpf);
            else if(_employee.Identifier == employee.Identifier)
                return Tuple.Create(true,"Já existe um funcionário com a matrícula: " + _employee.Identifier);
            else if(_employee.Email == employee.Email)
                return Tuple.Create(true,"Já existe um funcionário com o Email: " + _employee.Email);
            else    
                return Tuple.Create(false,"");
        }

        public override void Add(Employee employee)
        {
            employee.Active = true;
            base.Add(employee);
        }

        public override void Update(Employee employee)
        {
            var dbEmployee = base.GetById(employee.Id);
            dbContext.Entry(dbEmployee).State = EntityState.Detached;

            employee.Active = dbEmployee.Active;
            base.Update(employee);
        }

        public void Disable(Guid id)
        {
            var employee = base.GetById(id);
            employee.Active = false;
            base.Update(employee);
        }

        public void Enable(Guid id)
        {
            var employee = GetById(id);
            employee.Active = true;
            base.Update(employee);
        }

        public override Employee GetById(Guid id)
        {
            return dbContext.Employee.Include(p=> p.Branch).FirstOrDefault(p=> p.Id==id);
        }
    }
}
