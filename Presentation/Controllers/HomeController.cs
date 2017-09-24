using Aplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Home;

namespace Presentation.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILoanAppService _loanAppService;
        private readonly IItemAppService _itemAppService;

        public HomeController(ILoanAppService loanAppService, IItemAppService itemAppService)
        {
            _loanAppService = loanAppService;
            _itemAppService = itemAppService;
        }

        public IActionResult Index()
        {
            var model = new DashboardModel
            {
                LateLoansCount = _loanAppService.GetLateLoansCount(),
                NotLateLoansCount = _loanAppService.GetNotLateLoansCount(),
                AvailableItensCount = _itemAppService.GetAvailableItensForLoanCount(),
                AvaliableForDonationItensCount = _itemAppService.GetAvailableItensForDonationCount()
            };
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
