using System;
using System.Collections.Generic;
using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Aplication.Services.FileOperations;

namespace Aplication
{
    public class EmployeeAppService : AppServiceBase<Employee>, IEmployeeAppService
    {
        public readonly IEmployeeService _employeeService;
        public EmployeeAppService(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        public void Disable(Guid id)
        {
            _employeeService.Disable(id);
        }

        public void Enable(Guid id)
        {
            _employeeService.Enable(id);
        }

        public IEnumerable<Employee> GetAllWithoutUser()
        {
            return _employeeService.GetAllWithoutUser();
        }

        public Tuple<bool, string> IsDuplicatedEmployee(Employee employee)
        {
            return _employeeService.IsDuplicatedEmployee(employee);
        }

        public IEnumerable<Tuple<string,bool>> ImportEmployees(IFormFile file)
        {
            var content = FileReader.ReadStringFormFile(file);
            Console.WriteLine(content);

            //Separar o arquivo em uma lista de Objetos com os valores
            //Validar os Valores de cada elemento da lista
            //Pupular essa lista com os valore de referência a outra entidade
            //Enviar a lista para atualzação no banco
            return new List<Tuple<string,bool>>(){
                new Tuple<string,bool> ("José", true),
                new Tuple<string,bool> ("Maria", true),
                new Tuple<string,bool> ("Antonio", true)
            };
        }
    }
}
