using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Aplication.Interfaces;
using Domain.Entities;

namespace Presentation.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductAppService _productsAppService;

        public ProductsController(IProductAppService productsAppService)
        {
            _productsAppService = productsAppService;
        }

        public IActionResult Index(int page = 1)
        {
            var products = _productsAppService.GetPaged(page);
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel model)
        {
            return View();
        }

        public IActionResult Details(Guid id)
        {
            return View();
        }
    }
}
