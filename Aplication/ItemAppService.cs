using System;
using System.Collections.Generic;
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

        public IEnumerable<Item> GetAllAvailableForLoan()
        {
            return _itemService.GetAllAvailableForLoan();
        }

        public int GetAvailableItensForDonationCount()
        {
            return _itemService.GetAvailableItensForDonationCount();
        }

        public int GetAvailableItensForLoanCount()
        {
            return _itemService.GetAvailableItensForLoanCount();
        }
    }
}
