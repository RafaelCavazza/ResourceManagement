using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Infra.Data.Context;

namespace Infra.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20160825031945_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Domain.Entities.AplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("Hash");

                    b.Property<string>("LastName");

                    b.Property<string>("Salt");

                    b.HasKey("Id");

                    b.ToTable("AplicationUser");
                });
        }
    }
}
