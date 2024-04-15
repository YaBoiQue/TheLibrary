using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWarehouse.Data.Migrations.Warehouse
{
    /// <inheritdoc />
    public partial class FixedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Menucategory_Image",
                table: "menucategories");

            migrationBuilder.DropForeignKey(
                name: "MenuItem_Image",
                table: "menuitems");

            migrationBuilder.DropForeignKey(
                name: "Supplier_Image",
                table: "suppliers");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_ImageId",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_menuitems_ImageId",
                table: "menuitems");

            migrationBuilder.DropIndex(
                name: "IX_menucategories_ImageId",
                table: "menucategories");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "menuitems");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "menucategories");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "suppliers",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "menuitems",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "menucategories",
                type: "longblob",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "menuitems");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "menucategories");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "menuitems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "menucategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ImageId);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_ImageId",
                table: "suppliers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_menuitems_ImageId",
                table: "menuitems",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_menucategories_ImageId",
                table: "menucategories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "idImages_UNIQUE",
                table: "images",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "Menucategory_Image",
                table: "menucategories",
                column: "ImageId",
                principalTable: "images",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "MenuItem_Image",
                table: "menuitems",
                column: "ImageId",
                principalTable: "images",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "Supplier_Image",
                table: "suppliers",
                column: "ImageId",
                principalTable: "images",
                principalColumn: "ImageId");
        }
    }
}
