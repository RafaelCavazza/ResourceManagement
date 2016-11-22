using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntityConfig
{
    public class BranchConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(b =>
                {
                    b.HasKey(p=> p.Id);
                    b.Property(p=> p.Name).IsRequired().HasMaxLength(200);
                    b.Property(p=> p.Cnpj).IsRequired().HasMaxLength(30);
                });

            modelBuilder.Entity<Branch>().HasIndex(p=> p.Name).IsUnique();
            modelBuilder.Entity<Branch>().HasIndex(p=> p.Cnpj).IsUnique();

            modelBuilder.Entity<Branch>().HasMany(p=> p.Employees).WithOne(p=> p.Branch).HasForeignKey(p=> p.BranchId);
        }
    }
}
