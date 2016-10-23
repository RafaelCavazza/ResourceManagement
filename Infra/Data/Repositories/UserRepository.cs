using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;

namespace Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public override IEnumerable<User> GetAll()
        {
            return dbContext.User.Include(p => p.Employee).ToList();
        }

        public override IEnumerable<User> GetPaged(int pageIndex, int pageSize)
        {
            return dbContext.User.Include(p => p.Employee).ToPagedList(pageSize, pageIndex);
        }
    }
}
