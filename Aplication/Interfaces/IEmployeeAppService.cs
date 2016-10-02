using System;
using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IEmployeeAppService : IAppServiceBase<Employee>
    {
        Tuple<bool,string> IsDuplicatedEmployee(Employee employee);
    }
}