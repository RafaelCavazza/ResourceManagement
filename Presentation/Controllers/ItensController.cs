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

                //RN: Um item sempre é criado com o status Disponível
                mappedItem.Status = ItemStatus.Avaliable;

                mappedItem.NF = item.NF;
                mappedItem.SerialNumber = item.SerialNumber;
                mappedItem.Patrimonio = item.Patrimonio;

                _itemAppService.Add(mappedItem);
            }

            return RedirectToAction("Index");
        }
    }
}
