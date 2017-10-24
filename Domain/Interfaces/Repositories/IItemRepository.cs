using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        IEnumerable<Item> GetAllAvailableForLoan();

        int GetAvailableItensForLoanCount();

        int GetAvailableItensForDonationCount(); 
    }
}