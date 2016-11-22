using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntityConfig
{
    public class ProductConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(b =>
                {
                    b.HasKey(p=> p.Id);
                    b.Property(p=> p.Description).HasMaxLength(150).IsRequired();
                    b.Property(p=> p.ProductDepreciationTimeInMonths).IsRequired();
                    b.Property(p=> p.CreatedOn).IsRequired();
                    b.Property(p=> p.ModifiedOn).IsRequired();
                });
            
            modelBuilder.Entity<Product>().HasMany(p=> p.Items).WithOne(p=> p.Product).HasForeignKey(p=> p.ProductId);
        }
    }
}
