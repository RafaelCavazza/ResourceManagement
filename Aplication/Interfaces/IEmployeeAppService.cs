using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Aplication.Interfaces
{
    public interface IEmployeeAppService : IAppServiceBase<Employee>
    {
        Tuple<bool,string> IsDuplicatedEmployee(Employee employee);
        
        void Disable(Guid id);

        void Enable(Guid id);

        IEnumerable<Employee> GetAllWithoutUser();

        IEnumerable<Tuple<string,bool>> ImportEmployees(IFormFile file);
    }
}