using System;
using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Aplication
{
    public class EmployeeAppService : AppServiceBase<Employee>, IEmployeeAppService
    {
        public readonly IEmployeeService _employeeService;
        public EmployeeAppService(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        public Tuple<bool, string> IsDuplicatedEmployee(Employee employee)
        {
            return _employeeService.IsDuplicatedEmployee(employee);
        }
    }
}
