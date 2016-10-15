using System;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Tuple<bool,string> IsDuplicatedEmployee(Employee employee);

        void Disable(Guid id);

        void Enable(Guid id);
    }
}
