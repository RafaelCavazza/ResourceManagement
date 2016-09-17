using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infra.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        IEnumerable<Employee> IEmployeeRepository.GetByName(string name)
        {
            return dbContext.Employee.Where(p=> p.Name.Contains(name));
        }
    }
}
