using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Employee;
using Domain.Entities;
using System;
using Aplication.Interfaces;
using System.Linq;
using Aplication.Services.Email.Clients;
using Aplication.Services.Email.Interaces;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [Authorize]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeesController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public IActionResult Index()
        {
            var email = new SendGrid("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");
            email.Send("dontreply@resoucemanager.com",  new List<string> {"rafaelcavazza@gmail.com"}, "Teste", "<h1> Olá! </h1>", EmailContentType.Html);
            var employees = _employeeAppService.GetAll().OrderBy(p=> p.CreatedOn);
            return View(employees);            
        }

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
            
            var employee = Mapper.Map<Employee>(model);
            _employeeAppService.Add(employee);

            return RedirectToAction("Index");
        }


        public IActionResult Import()
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(Guid id)
        {
            var employee = _employeeAppService.GetById(id);
            var employeeViewModel = Mapper.Map<EditEmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            var employee = Mapper.Map<Employee>(model);
            _employeeAppService.Update(employee);
            return View("Index");
        }
    }
}
