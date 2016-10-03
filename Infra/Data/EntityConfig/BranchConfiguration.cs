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
                    b.Property(p=> p.Name).IsRequired();
                    b.Property(p=> p.Cnpj).IsRequired();
                });

            modelBuilder.Entity<Branch>().HasIndex(p=> p.Name).IsUnique();
            modelBuilder.Entity<Branch>().HasIndex(p=> p.Cnpj).IsUnique();
        }
    }
}
