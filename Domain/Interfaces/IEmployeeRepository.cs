using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        IEnumerable<Employee> GetByName(string name);   
    }
}
