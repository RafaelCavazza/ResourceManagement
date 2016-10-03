using System;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService : IServiceBase<Employee>
    {   
        Tuple<bool,string> IsDuplicatedEmployee(Employee employee);

        void Disable(Guid id);

        void Enable(Guid id);
    }
}
