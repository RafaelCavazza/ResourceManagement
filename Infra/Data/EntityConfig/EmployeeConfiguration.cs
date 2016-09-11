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
                });
            modelBuilder.Entity<Employee>().HasMany(p=> p.Users).WithOne(p=> p.Employee)
                    .HasForeignKey(p=> p.EmployeeId);
        }
    }
}
