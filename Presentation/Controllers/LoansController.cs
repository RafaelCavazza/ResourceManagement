using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aplication.Interfaces;
using Presentation.ViewModels.Loan;

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

        public IActionResult Create()
        {
            var model = new CreateLoanViewModel();
            
            return View(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateLoanViewModel model)
        {
        }
    }
}
