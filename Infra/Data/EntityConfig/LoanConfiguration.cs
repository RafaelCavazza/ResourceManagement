using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntityConfig
{
    public class LoanConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>(b =>
                {
                    b.HasKey(p=> p.Id);
                    b.Property(p=> p.StartDate).IsRequired();
                    b.Property(p=> p.EndDate).IsRequired();
                    b.Property(p=> p.ItemId).IsRequired();
                    b.Property(p=> p.EmployeeId).IsRequired();
                }); 
        }
    }
}
