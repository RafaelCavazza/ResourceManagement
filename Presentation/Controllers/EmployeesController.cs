using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Employee;
using Domain.Entities;
using System;
using Aplication.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Controllers
{
    [Authorize]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IBranchAppService _branchAppService;

        public EmployeesController(IEmployeeAppService employeeAppService, IBranchAppService branchAppService)
        {
            _employeeAppService = employeeAppService;
            _branchAppService = branchAppService;
        }

        public IActionResult Index()
        {
            //-----> Teste Para envio de Email
            //var email = new SendGrid("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");
            //email.Send("dontreply@resoucemanager.com",  new List<string> {"rafaelcavazza@gmail.com"}, "Teste", "<h1> Olá! </h1>", EmailContentType.Html);
            //-----> Teste Para envio de Email
            
            var employees = _employeeAppService.GetAll().OrderBy(p=> p.Name);
            return View(employees);            
        }

        public IActionResult Create()
        {
            var model = new CreateEmployeeViewModel();
            var branchs = _branchAppService.GetAll().ToList();
            model.Branch = new SelectList(branchs,"Id", "Name"); 
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            var employee = Mapper.Map<Employee>(model);
            var isDuplicated = _employeeAppService.IsDuplicatedEmployee(employee);

            if(isDuplicated.Item1)
                ModelState.AddModelError("CustomErrors",isDuplicated.Item2);

            if(!ModelState.IsValid)
            {
                var branchs = _branchAppService.GetAll().ToList();
                model.Branch = new SelectList(branchs,"Id", "Name"); 
                return View(model);
            }        
            
            _employeeAppService.Add(employee);

            return RedirectToAction("Index");
        }


        public IActionResult Import()
        {
            return View();
        }

        public IActionResult Details(Guid id)
        {
            var employee = _employeeAppService.GetById(id);
            var employeeViewModel = Mapper.Map<DetailsEmployeeViewModel>(employee);
            employeeViewModel.Branch = employee.Branch.Name; 
            
            return View(employeeViewModel);
        }

        public IActionResult Edit(Guid id)
        {
            var employee = _employeeAppService.GetById(id);
            
            var employeeViewModel = Mapper.Map<EditEmployeeViewModel>(employee);
            
            var branchs = _branchAppService.GetAll().ToList();
            employeeViewModel.Branch = new SelectList(branchs,"Id", "Name", employeeViewModel.BranchId); 
            
            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            var employee = Mapper.Map<Employee>(model);
            var isDuplicated = _employeeAppService.IsDuplicatedEmployee(employee);

            if(isDuplicated.Item1)
                ModelState.AddModelError("CustomErrors",isDuplicated.Item2);

            if(!ModelState.IsValid)
            {
                var branchs = _branchAppService.GetAll().ToList();
                model.Branch = new SelectList(branchs,"Id", "Name", model.BranchId); 
                return View(model);
            } 
        
            _employeeAppService.Update(employee);

            return RedirectToAction("Index");
        }

        public IActionResult Disable(Guid id)
        {
            _employeeAppService.Disable(id);   
            return RedirectToAction("Index");
        }

        public IActionResult Enable(Guid id)
        {
            _employeeAppService.Enable(id);   
            return RedirectToAction("Index");
        }
    }
}
