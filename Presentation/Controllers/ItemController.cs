using Aplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class ItensController : BaseController
    {
        private readonly IItemAppService _itemAppService;
        public ItensController(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public IActionResult Index(int page = 1)
        {
            var itens = _itemAppService.GetPaged(page);
            return View(itens);
        }
    }
}
