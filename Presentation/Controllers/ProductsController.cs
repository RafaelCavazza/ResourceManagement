using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Aplication.Interfaces;
using Domain.Entities;
using Presentation.ViewModels.Product;
using AutoMapper;

namespace Presentation.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public IActionResult Index(int page = 1)
        {
            var products = _productAppService.GetPaged(page);
            return View(products);
        }

        public IActionResult Create()
        {
            return View(new ProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            
            var product = Mapper.Map<Product>(model);
            _productAppService.Add(product);     

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        { 
            var product = _productAppService.GetById(id);
            var model = Mapper.Map<EditProductViewModel>(product);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditProductViewModel model)
        {
            var product = _productAppService.GetById(model.Id);
            var domainProduct = Mapper.Map<EditProductViewModel, Product>(model, product);
            _productAppService.Update(domainProduct);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var product = _productAppService.GetById(id);
            var model = Mapper.Map<ProductViewModel>(product);
            return View(model);
        }
    }
}
