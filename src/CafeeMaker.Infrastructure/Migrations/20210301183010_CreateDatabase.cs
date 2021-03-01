using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CafeeMaker.Infrastructure.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drink",
                columns: table => new
                {
                    drink_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    drink_name = table.Column<string>(type: "text", nullable: true),
                    drink_image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drink", x => x.drink_id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    ingredient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ingredient_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.ingredient_id);
                });

            migrationBuilder.CreateTable(
                name: "preference",
                columns: table => new
                {
                    preference_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    drink_id = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preference", x => x.preference_id);
                });

            migrationBuilder.CreateTable(
                name: "drink_ingredient",
                columns: table => new
                {
                    drink_ingredient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    drink_id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drink_ingredient", x => x.drink_ingredient_id);
                    table.ForeignKey(
                        name: "FK_drink_ingredient_drink_drink_id",
                        column: x => x.drink_id,
                        principalTable: "drink",
                        principalColumn: "drink_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_drink_ingredient_ingredient_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "ingredient",
                        principalColumn: "ingredient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "drink",
                columns: new[] { "drink_id", "drink_image", "drink_name" },
                values: new object[,]
                {
                    { 1, "/img/tea1.png", "Thé" },
                    { 2, "/img/coffee1.png", "Café" },
                    { 3, "/img/chocolate1.png", "Chocolat" }
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "employee_id", "firstname", "lastname" },
                values: new object[,]
                {
                    { 100, "AA1", "BB1" },
                    { 200, "AA2", "BB2" }
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
                    { 7, "Café" },
                    { 8, "Chocolat" }
                });

            migrationBuilder.InsertData(
                table: "drink_ingredient",
                columns: new[] { "drink_ingredient_id", "amount", "drink_id", "ingredient_id" },
                values: new object[,]
                {
                    { 1, 100, 1, 1 },
                    { 6, 20, 2, 1 },
                    { 2, 100, 1, 2 },
                    { 3, 50, 1, 3 },
                    { 7, 40, 2, 3 },
                    { 10, 30, 3, 3 },
                    { 5, 50, 2, 4 },
                    { 8, 100, 3, 5 },
                    { 4, 50, 2, 7 },
                    { 9, 100, 3, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_drink_ingredient_drink_id",
                table: "drink_ingredient",
                column: "drink_id");

            migrationBuilder.CreateIndex(
                name: "IX_drink_ingredient_ingredient_id",
                table: "drink_ingredient",
                column: "ingredient_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drink_ingredient");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "preference");

            migrationBuilder.DropTable(
                name: "drink");

            migrationBuilder.DropTable(
                name: "ingredient");
        }
    }
}
