using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ItemService : ServiceBase<Item>, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository) : base(itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public override void Add(Item item)
        {
            item.Status = ItemStatus.Avaliable;
            _itemRepository.Add(item);
        }
    }
}
