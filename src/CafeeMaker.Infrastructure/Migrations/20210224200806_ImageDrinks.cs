using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeeMaker.Infrastructure.Migrations
{
    public partial class ImageDrinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "drink_image",
                table: "drink",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "drink",
                keyColumn: "drink_id",
                keyValue: 1,
                column: "drink_image",
                value: "/img/tea.png");

            migrationBuilder.UpdateData(
                table: "drink",
                keyColumn: "drink_id",
                keyValue: 2,
                column: "drink_image",
                value: "/img/coffee.png");

            migrationBuilder.UpdateData(
                table: "drink",
                keyColumn: "drink_id",
                keyValue: 3,
                column: "drink_image",
                value: "/img/chocolate.png");

            migrationBuilder.CreateIndex(
                name: "IX_drink_ingredient_ingredient_id",
                table: "drink_ingredient",
                column: "ingredient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_drink_ingredient_ingredient_ingredient_id",
                table: "drink_ingredient",
                column: "ingredient_id",
                principalTable: "ingredient",
                principalColumn: "ingredient_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drink_ingredient_ingredient_ingredient_id",
                table: "drink_ingredient");

            migrationBuilder.DropIndex(
                name: "IX_drink_ingredient_ingredient_id",
                table: "drink_ingredient");

            migrationBuilder.DropColumn(
                name: "drink_image",
                table: "drink");
        }
    }
}
