using System;
using System.Collections.Generic;
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

        public IEnumerable<Item> GetAllAvailableForLoan()
        {
            return _itemRepository.GetAllAvailableForLoan();
        }

        public int GetAvailableItensForDonationCount()
        {
            return _itemRepository.GetAvailableItensForDonationCount();
        }

        public int GetAvailableItensForLoanCount()
        {
            return _itemRepository.GetAvailableItensForLoanCount();
        }
    }
}
