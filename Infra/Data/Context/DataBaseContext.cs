using Microsoft.EntityFrameworkCore;
using Infra.Data.EntityConfig;
using Domain.Entities;

namespace Infra.Data.Context
{
    public class DataBaseContext : DbContext
    {    
        public DbSet<Employee> Employee {get; set;}
        public DbSet<User> User {get; set;}
        public DbSet<Role> Role {get; set;}
        public DbSet<Branch> Branch {get; set;}
        public DbSet<Item> Item {get; set;}
        public DbSet<Product> Product {get; set;}
        public DbSet<Loan> Loan {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=database.db");
            //optionBuilder.UseSqlServer("Server=ec2-52-67-112-140.sa-east-1.compute.amazonaws.com;Database=Aplication;User Id=sa;Password=A1a2$bcde;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EmployeeConfiguration.Configure(modelBuilder);
            IdentityConfiguration.Configure(modelBuilder);
            BranchConfiguration.Configure(modelBuilder);
            ItemConfiguration.Configure(modelBuilder);
            ProductConfiguration.Configure(modelBuilder);
            LoanConfiguration.Configure(modelBuilder);
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

                    if(entry.Property("ModifiedOn") != null)
                        entry.Property("ModifiedOn").CurrentValue = System.DateTime.Now;
                }
                else if(entry.State == EntityState.Modified)
                {
                    if(entry.Property("ModifiedOn") != null)
                        entry.Property("ModifiedOn").CurrentValue = System.DateTime.Now;
                    if(entry.Property("CreatedOn") != null)
                        entry.Property("CreatedOn").IsModified =false;
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
