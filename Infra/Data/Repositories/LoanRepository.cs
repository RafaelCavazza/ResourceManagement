using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;


namespace Infra.Data.Repositories
{
    public class LoanRepository : RepositoryBase<Loan>, ILoanRepository
    {
        public int GetLateLoansCount()
        {
            return dbContext.Loan.Count(o => o.EndDate < DateTime.Now);
        }

        public int GetNotLateLoansCount()
        {
           return dbContext.Loan.Count(o => o.EndDate >= DateTime.Now);
        }

        public override IEnumerable<Loan> GetPaged(int pageIndex, int pageSize)
        {
            return dbContext.Loan
            .Include(p => p.Item.Product)
            .Include(p => p.Item)
            .Include(p => p.Employee)
            .ToPagedList(pageSize, pageIndex);
        }
    }
}
