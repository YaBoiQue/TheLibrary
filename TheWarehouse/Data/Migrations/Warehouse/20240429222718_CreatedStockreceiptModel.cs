using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWarehouse.Data.Migrations.Warehouse
{
    /// <inheritdoc />
    public partial class CreatedStockreceiptModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockreceiptId",
                table: "stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "stockreceipts",
                columns: table => new
                {
                    StockreceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    datetimepurchased = table.Column<DateTime>(type: "datetime", nullable: false),
                    ImageName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    timestamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.StockreceiptId);
                    table.ForeignKey(
                        name: "Stockreceipt_Supplier",
                        column: x => x.SupplierId,
                        principalTable: "suppliers",
                        principalColumn: "SupplierId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "Stock_Stockreceipt_idx",
                table: "stocks",
                column: "StockreceiptId");

            migrationBuilder.CreateIndex(
                name: "Stock_Users_idx1",
                table: "stockreceipts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Stockreceipt_Supplier_idx",
                table: "stockreceipts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "StockreceiptId_UNIQUE",
                table: "stockreceipts",
                column: "StockreceiptId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "Stock_Stockreceipt",
                table: "stocks",
                column: "StockreceiptId",
                principalTable: "stockreceipts",
                principalColumn: "StockreceiptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Stock_Stockreceipt",
                table: "stocks");

            migrationBuilder.DropTable(
                name: "stockreceipts");

            migrationBuilder.DropIndex(
                name: "Stock_Stockreceipt_idx",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "StockreceiptId",
                table: "stocks");
        }
    }
}
