using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWarehouse.Data.Migrations.Warehouse
{
    /// <inheritdoc />
    public partial class ImagePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "suppliers",
                type: "longtext",
                nullable: true,
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "suppliers",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "menuitems",
                type: "longtext",
                nullable: true,
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "menuitems",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "menucategories",
                type: "longtext",
                nullable: true,
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "menuitems");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "menuitems");

            migrationBuilder.DropColumn(
                name: "ImageName",
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
    }
}
