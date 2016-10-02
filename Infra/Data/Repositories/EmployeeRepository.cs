using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infra.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public IEnumerable<Employee> GetByName(string name)
        {
            return dbContext.Employee.Where(p=> p.Name.Contains(name));
        }

        public Tuple<bool, string> IsDuplicatedEmployee(Employee employee)
        {
            var _employee = dbContext.Employee.FirstOrDefault( p=> 
            p.Identifier == employee.Identifier ||
            p.Cpf == employee.Cpf ||
            p.Email == employee.Email);

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
    }
}
