using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
