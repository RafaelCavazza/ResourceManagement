using System;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class EmployeeService : ServiceBase<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Disable(Guid id)
        {
            _employeeRepository.Disable(id);
        }

        public void Enable(Guid id)
        {
            _employeeRepository.Enable(id);
        }

        public Tuple<bool, string> IsDuplicatedEmployee(Employee employee)
        {
            return _employeeRepository.IsDuplicatedEmployee(employee);
        }
    }
}
