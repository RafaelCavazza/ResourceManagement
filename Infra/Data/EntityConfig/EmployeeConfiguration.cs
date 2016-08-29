using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                    b.Property(p=> p.FirstName).HasMaxLength(50).IsRequired();
                    b.Property(p=> p.LastName).HasMaxLength(50).IsRequired();
                });
        }
    }
}
