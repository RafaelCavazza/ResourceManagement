using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public override IEnumerable<User> GetAll()
        {
            return dbContext.User.Include(p=> p.Employee).ToList();
        }
    }
}
