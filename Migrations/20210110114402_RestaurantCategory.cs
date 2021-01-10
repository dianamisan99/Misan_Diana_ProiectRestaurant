using Microsoft.EntityFrameworkCore.Migrations;

namespace Misan_Diana_ProiectRestaurant.Migrations
{
    public partial class RestaurantCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayMethodID",
                table: "Restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PayMethod",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayMethodName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RestaurantCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCategory_Restaurant_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_PayMethodID",
                table: "Restaurant",
                column: "PayMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCategory_CategoryID",
                table: "RestaurantCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCategory_RestaurantID",
                table: "RestaurantCategory",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_PayMethod_PayMethodID",
                table: "Restaurant",
                column: "PayMethodID",
                principalTable: "PayMethod",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_PayMethod_PayMethodID",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "PayMethod");

            migrationBuilder.DropTable(
                name: "RestaurantCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_PayMethodID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "PayMethodID",
                table: "Restaurant");
        }
    }
}
