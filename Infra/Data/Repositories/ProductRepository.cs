using Domain.Entities;
using Domain.Interfaces.Repositories;
using Sakura.AspNetCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public override IEnumerable<Product> GetPaged(int pageIndex, int pageSize)
        {
            return dbContext.Product.OrderBy(p=> p.CreatedOn).ToPagedList(pageSize, pageIndex);
        }
    }
}
