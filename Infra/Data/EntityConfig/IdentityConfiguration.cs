using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Infra.Data.EntityConfig
{
    public class IdentityConfiguration 
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            //Aqui entra a configuração dos modelos do Identity, pendente refatorar em classe distintas
            modelBuilder.Entity<User>(b =>
                {
                    b.HasKey(p=> p.Id);
                });

            modelBuilder.Entity<Employee>().HasMany(p=> p.Users).WithOne(p=> p.Employee)
                    .HasForeignKey(p=> p.EmployeeId);

            modelBuilder.Entity<Role>(b =>
                {
                    b.HasKey(p=> p.Id);
                });
            
            modelBuilder.Entity<IdentityUserRole<Guid>>(b =>
                {
                    b.HasKey(p=> new { p.UserId, p.RoleId});
                });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
                {
                    b.HasKey(p=> new { p.UserId, p.ProviderKey});
                });
            
             modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole");
             modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin");
             modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
             modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
             
        }
    }
}
