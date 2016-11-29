using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aplication.Interfaces;
using Presentation.ViewModels.Loan;
using AutoMapper;
using System.Collections.Generic;
using Domain.Entities;

namespace Presentation.Controllers
{
    [Authorize]
    public class LoansController : BaseController
    {
        private readonly ILoanAppService _loanAppService;

        public LoansController(ILoanAppService loanAppService)
        {
            _loanAppService = loanAppService;
        }

        public IActionResult Index(int page = 1)
        {
            var loans = _loanAppService.GetPaged(page);
            return View(loans);
        }

    }
}
