using System.Collections.Generic;
using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IItemAppService :IAppServiceBase<Item>
    {
        IEnumerable<Item> GetAllAvailableForLoan();

        int GetAvailableItensForLoanCount();

        int GetAvailableItensForDonationCount(); 
    }
}
