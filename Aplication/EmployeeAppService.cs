using System;
using System.Collections.Generic;
using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Aplication.Services.FileOperations;
using System.Linq;

namespace Aplication
{
    public class EmployeeAppService : AppServiceBase<Employee>, IEmployeeAppService
    {
        public readonly IEmployeeService _employeeService;
        public readonly IBranchService _branchService;

        public EmployeeAppService(IEmployeeService employeeService, IBranchService branchService) : base(employeeService)
        {
            _employeeService = employeeService;
            _branchService = branchService;
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
            var value = new List<Tuple<string,bool>>();

            var content = FileReader.ReadStringFormFile(file);
            
            //TODO: TEMINAR DE IMPLEMENTAR A IMPORTAÇÃO DE FUNCIONÁRIOS.
            var lines = content.Split(new [] { Environment.NewLine }, StringSplitOptions.None);
            var header = new[] { "FILIAL", "MATRICULA", "NOME", "CPF", "DATA", "ADMISSAO", "E-MAIL", "COORDENADOR" };
            foreach(var line in lines)
            {
                if(header.Any(c => line.Contains(c)) )
                    continue;

                var collumns = line.Split(';',',');
                value.Add(new Tuple<string,bool> (collumns[2], true));
            }
            
            //Separar o arquivo em uma lista de Objetos com os valores
            //Validar os Valores de cada elemento da lista
            //Pupular essa lista com os valore de referência a outra entidade
            //Enviar a lista para atualzação no banco
            return value;
        }
    }
}
