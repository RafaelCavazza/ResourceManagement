using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        IEnumerable<Employee> GetByName(string name);   

        Tuple<bool,string> IsDuplicatedEmployee(Employee employee);

        void Disable(Guid id);

        void Enable(Guid id);
    }
}
