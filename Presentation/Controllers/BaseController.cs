using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult RedirectToLocal(string returnUrl)
        {
            if(!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home", new {});
        }
    }
}
