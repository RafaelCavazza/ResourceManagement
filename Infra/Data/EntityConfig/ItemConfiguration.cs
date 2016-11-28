using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntityConfig
{
    public class ItemConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.PurchasedOn).IsRequired();
                b.Property(p => p.NF).IsRequired();
                b.Property(p => p.SerialNumber).IsRequired();
                b.Property(p => p.Patrimonio).IsRequired();
                b.Property(p => p.Status).IsRequired();
                b.Property(p => p.CreatedOn).IsRequired();
                b.Property(p => p.ModifiedOn).IsRequired();
            });

            modelBuilder.Entity<Item>().HasMany(p=> p.Loans).WithOne(p=> p.Item).HasForeignKey(p=> p.ItemId);
        }
    }
}
