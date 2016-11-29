using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;

namespace Infra.Data.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public override IEnumerable<Item> GetPaged(int pageIndex, int pageSize)
        {
            return dbContext.Item.Include(p => p.Product).ToPagedList(pageSize, pageIndex);
        }    
    }
}
