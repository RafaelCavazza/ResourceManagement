using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Employee;

namespace Presentation.Controllers
{
    [Authorize]
    public class EmployeesController : BaseController
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditEmplyeeViewModel model)
        {
            return View();
        }

    }
}
