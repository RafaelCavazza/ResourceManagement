using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Employee;
using Domain.Entities;
using System;
using Aplication.Interfaces;

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
            var employees = _employeeAppService.GetAll();
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

            return View("Index");
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
