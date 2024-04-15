using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWarehouse.Data.Migrations.Warehouse
{
    /// <inheritdoc />
    public partial class FixedMenuCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "menuitems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "menuitems",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");
        }
    }
}
