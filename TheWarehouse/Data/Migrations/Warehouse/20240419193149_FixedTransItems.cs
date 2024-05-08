using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWarehouse.Data.Migrations.Warehouse
{
    /// <inheritdoc />
    public partial class FixedTransItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuitemId",
                table: "transactionitems",
                newName: "MenuItemId");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "transactionitems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "MenuitemId",
                table: "ingredients",
                newName: "MenuItemId");

            migrationBuilder.AlterColumn<string>(
                name: "updated_userId",
                table: "menuitems",
                type: "varchar(255)",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldCollation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "created_userId",
                table: "menuitems",
                type: "varchar(255)",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldCollation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "transactionitems",
                newName: "MenuitemId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "transactionitems",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "ingredients",
                newName: "MenuitemId");

            migrationBuilder.UpdateData(
                table: "menuitems",
                keyColumn: "updated_userId",
                keyValue: null,
                column: "updated_userId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "updated_userId",
                table: "menuitems",
                type: "varchar(255)",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldCollation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "menuitems",
                keyColumn: "created_userId",
                keyValue: null,
                column: "created_userId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "created_userId",
                table: "menuitems",
                type: "varchar(255)",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldCollation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
