using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infra.Data.EntityConfig;
using System;
using System.Linq;

namespace Infra.Data.Context
{
    public class DataBaseContext : DbContext
    {    
        public DbSet<Employee> Employee {get; set;}
        public DbSet<User> User {get; set;}
        public DbSet<Role> Role {get; set;}

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DataBaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlite("Filename=database.db");
            optionBuilder.UseSqlServer("Server=ec2-52-67-112-140.sa-east-1.compute.amazonaws.com;Database=Aplication;User Id=sa;Password=A1a2$bcde;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EmployeeConfiguration.Configure(modelBuilder);
            IdentityConfiguration.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        //Refatorar Esse Código, o seed deve ficar em outro lugar 
        public void Seed()
        {
            var id = new Guid("5ff9b5a9-89aa-42d4-9296-be9a80ab4243");
            if(this.Employee.FirstOrDefault(p=> p.Id==id)==null)
            {
                var employee = new Employee { Id = id, Name="Admin"};
                this.Employee.Add(employee);
                this.SaveChanges();
            }

            var userId = new Guid("62CDA543-F838-483D-98E3-08D3DA5C1A98");
            if(this.User.FirstOrDefault(p=> p.Id==id)==null)
            {
                var user = new User 
                { 
                    Id = userId,
                    ConcurrencyStamp = "b0d2c68c-07a4-4896-a2aa-b9a15360e25f",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                    EmployeeId = id,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAEAACcQAAAAEH2+BZCX1SyzotQcYVrRCPx/rr7Uky0iB06uu/mRZQpVL/Kg9rrFXY1fQqTlvWTZMg==",
                    SecurityStamp = "2b654aa8-3ef9-4675-a708-377541394a97",
                    UserName = "admin@gmail.com"
                    };
                this.User.Add(user);
                this.SaveChanges();
            }
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
