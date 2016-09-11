using Microsoft.EntityFrameworkCore;
using Domain.Entities;

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
            modelBuilder.Entity<User>().HasMany(p=> p.Roles).WithOne(p=> p.User)
                    .HasForeignKey(p=> p.UserId);
            modelBuilder.Entity<User>().HasMany(p=> p.Claims).WithOne(p=> p.User)
                    .HasForeignKey(p=> p.UserId);
            modelBuilder.Entity<User>().HasMany(p=> p.Logins).WithOne(p=> p.User)
                    .HasForeignKey(p=> p.UserId);
        
            modelBuilder.Entity<Role>(b =>
                {
                    b.HasKey(p=> p.Id);
                });
            modelBuilder.Entity<Role>().HasMany(p=> p.Users).WithOne(p=> p.Role)
                .HasForeignKey(p=> p.RoleId);
            modelBuilder.Entity<Role>().HasMany(p=> p.Claims).WithOne(p=> p.Role)
                .HasForeignKey(p=> p.RoleId);
        
            modelBuilder.Entity<UserClaim>(b =>
                {
                    b.HasKey(p=> new {p.Id});
                });

            modelBuilder.Entity<RoleClaim>(b =>
                {
                    b.HasKey(p=> p.Id);
                });
            
            modelBuilder.Entity<UserLogin>(b =>
                {
                    b.HasKey(p=> p.Id);
                });
        }
    }
}
