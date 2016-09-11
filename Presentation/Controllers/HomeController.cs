using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var user  = User.Identity.Name;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
