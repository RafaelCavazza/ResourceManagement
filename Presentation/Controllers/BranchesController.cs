using System;
using System.Linq;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Branch;

namespace Presentation.Controllers
{
    [Authorize]
    public class BranchesController : BaseController
    {
        private readonly IBranchAppService _branchAppService;

        public BranchesController(IBranchAppService branchAppService)
        {
            _branchAppService = branchAppService;
        }

        public IActionResult Index()
        {
            var branches = _branchAppService.GetAll().OrderBy(p => p.Name);
            return View(branches);
        }

        public IActionResult Create()
        {
            return View(new CreateBranchViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateBranchViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Create", model);

            var branch = Mapper.Map<Branch>(model);

            _branchAppService.Add(branch);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var branch = _branchAppService.GetById(id);
            var branchViewModel = Mapper.Map<DetailsBranchViewModel>(branch);

            return View(branchViewModel);
        }

        public IActionResult Delete(Guid id)
        {
            var branch = _branchAppService.GetById(id);
            if(branch.Employees.Any())
            {
                TempData["Error"] = "Não é possível deletar uma Unidade que está associada a um Funcionário";
                return RedirectToAction("Details", id);
            }

            _branchAppService.Remove(branch);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var branch = _branchAppService.GetById(id);
            var branchViewModel = Mapper.Map<EditBranchViewModel>(branch);

            return View(branchViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditBranchViewModel model)
        {
            if(!ModelState.IsValid)
                return View("Edit", model);

            var branch = Mapper.Map<Branch>(model);
            _branchAppService.Update(branch);

            return RedirectToAction("Index");
        }
    }
}
