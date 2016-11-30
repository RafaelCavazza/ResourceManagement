using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aplication.Interfaces;
using Presentation.ViewModels.Loan;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using AutoMapper;
using Domain.Entities;

namespace Presentation.Controllers
{
    [Authorize]
    public class LoansController : BaseController
    {
        private readonly ILoanAppService _loanAppService;
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IItemAppService _itemAppService;

        public LoansController(ILoanAppService loanAppService, IEmployeeAppService employeeAppService, IItemAppService itemAppService)
        {
            _loanAppService = loanAppService;
            _employeeAppService = employeeAppService;
            _itemAppService = itemAppService;
        }

        public IActionResult Index(int page = 1)
        {
            var loans = _loanAppService.GetPaged(page);
            return View(loans);
        }

        public IActionResult Create()
        {
            var model = new CreateLoanViewModel();
            model.Employees = _employeeAppService.GetAll();
            model.Items =  _itemAppService.GetAllAvailableForLoan();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateLoanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Employees = _employeeAppService.GetAll();
                model.Items =  _itemAppService.GetAllAvailableForLoan();
                return View("Create", model);
            }
            var loan =  Mapper.Map<Loan>(model);
            _loanAppService.Add(loan);
            
            return RedirectToAction("Index");
        }
    }
}
