using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Migration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NF",
                table: "Item",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Patrimonio",
                table: "Item",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchasedOn",
                table: "Item",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Item",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Item",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NF",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Patrimonio",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PurchasedOn",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Item");
        }
    }
}
