using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Data.EntityConfig
{
    public class AplicationUserConfiguration 
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AplicationUser>(b =>
                {
                    b.HasKey(p=> p.Id);

                    b.Property(p=> p.CreatedOn).IsRequired();
                    b.Property(p=> p.ModifiedOn).IsRequired();
                    b.Property(p=> p.Email).HasMaxLength(200).IsRequired();
                    b.Property(p=> p.Hash).HasMaxLength(500).IsRequired();
                    b.Property(p=> p.Salt).HasMaxLength(100).IsRequired();
                    b.Property(p=> p.Active).IsRequired();
                });
        }
    }
}
