using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;

namespace Infra.Data.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public IEnumerable<Item> GetAllAvailableForLoan()
        {
            return
                from itemDb in dbContext.Item.Include(i=> i.Product)
                where
                    itemDb.Loans.All(l => l.HasFinished) &&
                    itemDb.Status == ItemStatus.Avaliable
                select
                    itemDb;
        }

        public override IEnumerable<Item> GetPaged(int pageIndex, int pageSize)
        {
            return dbContext.Item.Include(p => p.Product).ToPagedList(pageSize, pageIndex);
        }

        public int GetAvailableItensForDonationCount()
        {
            return dbContext.Item.Count(o => o.Status == ItemStatus.AvaliableForDonation);
        }

        public int GetAvailableItensForLoanCount()
        {
            return dbContext.Item.Count(o => o.Status == ItemStatus.Avaliable);
        }
    }
}
