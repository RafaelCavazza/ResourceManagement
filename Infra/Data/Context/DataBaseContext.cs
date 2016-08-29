using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infra.Data.EntityConfig;

namespace Infra.Data.Context
{
    public class DataBaseContext : DbContext
    {
        //Entidades do Domínio
        
        public DbSet<AplicationUser> Employee {get; set;}
        public DbSet<AplicationUser> AplicationUser {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite("Filename=database.db");
            //optionBuilder.UseSqlServer("Server=ec2-52-67-98-128.sa-east-1.compute.amazonaws.com;Database=Aplication;User Id=appUser;Password=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AplicationUserConfiguration.Configure(modelBuilder);
            EmployeeConfiguration.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.State==EntityState.Added)
                {
                    if(entry.Property("CreatedOn") != null)
                        entry.Property("CreatedOn").CurrentValue = System.DateTime.Now;
                }
                else if(entry.State == EntityState.Modified)
                {
                    if(entry.Property("ModifiedOn") != null)
                        entry.Property("ModifiedOn").CurrentValue = System.DateTime.Now;
                }
                else
                {
                    if(entry.Property("CreatedOn") != null)
                        entry.Property("CreatedOn").IsModified =false;

                    if(entry.Property("ModifiedOn") != null)
                        entry.Property("ModifiedOn").IsModified = false;
                }
            }
            
            return base.SaveChanges();
        }
    }
}
