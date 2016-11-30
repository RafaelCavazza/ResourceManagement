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
            return dbContext.Item
            .Include(p=> p.Loans)
            .Include(p=> p.Product).Where(i=> i.IsAvailableForLoan()).ToList();
        }

        public override IEnumerable<Item> GetPaged(int pageIndex, int pageSize)
        {
            return dbContext.Item.Include(p => p.Product).ToPagedList(pageSize, pageIndex);
        }
    }
}
