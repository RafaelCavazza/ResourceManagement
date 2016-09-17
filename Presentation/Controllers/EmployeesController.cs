using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Employee;
using Domain.Entities;
using System;
using Presentation.AutoMapper;

namespace Presentation.Controllers
{
    [Authorize]
    public class EmployeesController : BaseController
    {
        public IActionResult Create()
        {
            var model = new CreateEmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            
            //Exemplo de Como usar e configurar o AutoMapper RAFATORAR
            //AutoMapperConfig.RegisterMapping();
            //var mppedEntityTest = Mapper.Map<Employee>(model);
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            return View();
        }
    }
}
