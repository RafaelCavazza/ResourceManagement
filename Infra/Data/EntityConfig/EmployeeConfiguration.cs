using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntityConfig
{
    public class EmployeeConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(b =>
                {
                    b.HasKey(p=> p.Id);
                    b.Property(p=> p.Name).HasMaxLength(150).IsRequired();
                    b.Property(p=> p.Email).HasMaxLength(200).IsRequired();
                    b.Property(p=> p.Cpf).HasMaxLength(20).IsRequired();

                    b.Property(p=> p.DateOfBirth).IsRequired();
                    b.Property(p=> p.CreatedOn).IsRequired();
                    b.Property(p=> p.ModifiedOn).IsRequired();
                });
            
            modelBuilder.Entity<Employee>().HasIndex(p=> p.Cpf).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(p=> p.Email).IsUnique();

            modelBuilder.Entity<Employee>().HasMany(p=> p.Users).WithOne(p=> p.Employee)
                    .HasForeignKey(p=> p.EmployeeId);
        }
    }
}
