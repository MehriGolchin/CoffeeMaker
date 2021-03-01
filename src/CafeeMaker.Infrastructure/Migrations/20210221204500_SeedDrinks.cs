using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeeMaker.Infrastructure.Migrations
{
    public partial class SeedDrinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "drink_ingredient",
                newName: "drink_ingredient_id");

            migrationBuilder.InsertData(
                table: "drink",
                columns: new[] { "drink_id", "drink_name" },
                values: new object[,]
                {
                    { 1, "Thé" },
                    { 2, "Café" },
                    { 3, "Chocolat" }
                });

            migrationBuilder.InsertData(
                table: "ingredient",
                columns: new[] { "ingredient_id", "ingredient_name" },
                values: new object[,]
                {
                    { 1, "Eau chaude" },
                    { 2, "Thé noir" },
                    { 3, "Sucre" },
                    { 4, "Lait" },
                    { 5, "Crème fouettée" },
                    { 6, "Eau froide" },
                    { 7, "Café" }
                });

            migrationBuilder.InsertData(
                table: "drink_ingredient",
                columns: new[] { "drink_ingredient_id", "amount", "drink_id", "ingredient_id" },
                values: new object[,]
                {
                    { 1, 100, 1, 1 },
                    { 2, 100, 1, 2 },
                    { 3, 50, 1, 3 },
                    { 4, 50, 2, 7 },
                    { 5, 50, 2, 4 },
                    { 6, 20, 2, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "drink",
                keyColumn: "drink_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "drink_ingredient",
                keyColumn: "drink_ingredient_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "drink_ingredient",
                keyColumn: "drink_ingredient_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "drink_ingredient",
                keyColumn: "drink_ingredient_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "drink_ingredient",
                keyColumn: "drink_ingredient_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "drink_ingredient",
                keyColumn: "drink_ingredient_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "drink_ingredient",
                keyColumn: "drink_ingredient_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ingredient",
                keyColumn: "ingredient_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ingredient",
                keyColumn: "ingredient_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ingredient",
                keyColumn: "ingredient_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ingredient",
                keyColumn: "ingredient_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ingredient",
                keyColumn: "ingredient_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ingredient",
                keyColumn: "ingredient_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ingredient",
                keyColumn: "ingredient_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "drink",
                keyColumn: "drink_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "drink",
                keyColumn: "drink_id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "drink_ingredient_id",
                table: "drink_ingredient",
                newName: "Id");
        }
    }
}
