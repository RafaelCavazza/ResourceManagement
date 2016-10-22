using System;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public override Branch GetById(Guid id)
        {
            return dbContext.Branch.Include(o => o.Employees).FirstOrDefault(p => p.Id == id);
        }
    }
}
