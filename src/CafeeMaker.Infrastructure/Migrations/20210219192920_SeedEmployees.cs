using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeeMaker.Infrastructure.Migrations
{
    public partial class SeedEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "employee_id", "firstname", "lastname" },
                values: new object[,]
                {
                    { 1, "AA1", "BB1" },
                    { 2, "AA2", "BB2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "employee_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "employee_id",
                keyValue: 2);
        }
    }
}
