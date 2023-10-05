using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class ShopCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beer_Category_categoryID",
                table: "Beer");

            migrationBuilder.RenameColumn(
                name: "categoryName",
                table: "Category",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "categoryDescription",
                table: "Category",
                newName: "CategoryDescription");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Category",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "shortDesc",
                table: "Beer",
                newName: "ShortDesc");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Beer",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "longDesc",
                table: "Beer",
                newName: "LongDesc");

            migrationBuilder.RenameColumn(
                name: "isFavourite",
                table: "Beer",
                newName: "IsFavourite");

            migrationBuilder.RenameColumn(
                name: "img",
                table: "Beer",
                newName: "Img");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "Beer",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "availablbe",
                table: "Beer",
                newName: "Availablbe");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Beer",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Beer_categoryID",
                table: "Beer",
                newName: "IX_Beer_CategoryID");

            migrationBuilder.CreateTable(
                name: "ShopCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeerId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    ShopCartId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCartItems_Beer_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItems_BeerId",
                table: "ShopCartItems",
                column: "BeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beer_Category_CategoryID",
                table: "Beer",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beer_Category_CategoryID",
                table: "Beer");

            migrationBuilder.DropTable(
                name: "ShopCartItems");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "categoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "Category",
                newName: "categoryDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ShortDesc",
                table: "Beer",
                newName: "shortDesc");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Beer",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "LongDesc",
                table: "Beer",
                newName: "longDesc");

            migrationBuilder.RenameColumn(
                name: "IsFavourite",
                table: "Beer",
                newName: "isFavourite");

            migrationBuilder.RenameColumn(
                name: "Img",
                table: "Beer",
                newName: "img");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Beer",
                newName: "categoryID");

            migrationBuilder.RenameColumn(
                name: "Availablbe",
                table: "Beer",
                newName: "availablbe");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Beer",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Beer_CategoryID",
                table: "Beer",
                newName: "IX_Beer_categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beer_Category_categoryID",
                table: "Beer",
                column: "categoryID",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
