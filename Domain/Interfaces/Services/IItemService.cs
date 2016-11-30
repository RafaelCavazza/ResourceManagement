using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IItemService : IServiceBase<Item>
    {
        IEnumerable<Item> GetAllAvailableForLoan();
    }
}
