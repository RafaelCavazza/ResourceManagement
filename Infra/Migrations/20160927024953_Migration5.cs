using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                maxLength: 200,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "Employee",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Cpf",
                table: "Employee",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Email",
                table: "Employee",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_Cpf",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Email",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "Employee",
                nullable: true);
        }
    }
}
