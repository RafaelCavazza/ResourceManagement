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
                    b.HasKey(p=> p.Id);
                    b.Property(p=> p.CreatedOn).IsRequired();
                    b.Property(p=> p.ModifiedOn).IsRequired();
                });
        }
    }
}
