using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infra.Data.EntityConfig;
using System;

namespace Infra.Data.Context
{
    public class DataBaseContext : DbContext
    {    
        public DbSet<Employee> Employee {get; set;}
        public DbSet<User> User {get; set;}
        public DbSet<Role> Role {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlite("Filename=database.db");
            optionBuilder.UseSqlServer("Server=ec2-52-67-112-140.sa-east-1.compute.amazonaws.com;Database=Aplication;User Id=sa;Password=*****;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EmployeeConfiguration.Configure(modelBuilder);
            IdentityConfiguration.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        //Refatorar Esse Código, o seed deve ficar em outro lugar 
        public void Seed(DataBaseContext dbContext)
        {
            var id = new Guid("5ff9b5a9-89aa-42d4-9296-be9a80ab4243");
            var employee = new Employee { Id = id, FirstName="Admin", LastName="" };
            dbContext.Employee.Add(employee);
            dbContext.SaveChanges();
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
