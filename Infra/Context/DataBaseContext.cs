using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infra.EntityConfig;

namespace Infra.Context
{
    public class DataBaseContext : DbContext
    {
        //Entidades do Domínio
        public DbSet<AplicationUser> AplicationUser {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite("Filename=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AplicationUserConfiguration.Configure(modelBuilder);
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
