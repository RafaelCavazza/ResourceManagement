using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Aplication
{
    public class ItemAppService  : AppServiceBase<Item>, IItemAppService
    {
        public readonly IItemService _itemService;

        public ItemAppService(IItemService itemService) : base(itemService)
        { 
            _itemService = itemService;
        }
    }
}
