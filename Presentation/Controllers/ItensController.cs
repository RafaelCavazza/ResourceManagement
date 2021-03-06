using System;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.ViewModels.Item;

namespace Presentation.Controllers
{
    [Authorize]
    public class ItensController : BaseController
    {
        private readonly IItemAppService _itemAppService;
        private readonly IProductAppService _productAppService;
        
        public ItensController(IItemAppService itemAppService, IProductAppService productAppService)
        {
            _itemAppService = itemAppService;
            _productAppService = productAppService;
        }

        public IActionResult Index(int page = 1)
        {
            var itens = _itemAppService.GetPaged(page);
            return View(itens);
        }

        public IActionResult Create()
        {
            var model = new CreateItemViewModel();
            var products = _productAppService.GetAll();
            model.Products = new SelectList(products, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateItemViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Create", model);
            
            foreach(var item in model.Itens){
                var mappedItem = Mapper.Map<Item>(model);
                
                mappedItem.NF = item.NF;
                mappedItem.SerialNumber = item.SerialNumber;
                mappedItem.Patrimonio = item.Patrimonio;

                _itemAppService.Add(mappedItem);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var item = _itemAppService.GetById(id);
            var model = Mapper.Map<EditItemViewModel>(item);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditItemViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Edit", model);

            var dataBaseItem = _itemAppService.GetById(model.Id);
            var item = Mapper.Map<EditItemViewModel, Item>(model, dataBaseItem);
            _itemAppService.Update(item);

            return RedirectToAction("Index");
        }
    }
}
