using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;

namespace Infra.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<AplicationUser> AplicationUser {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite("Filename=database.db");
        }

        public DataBaseContext() : base()
        {

        }
    }
}
