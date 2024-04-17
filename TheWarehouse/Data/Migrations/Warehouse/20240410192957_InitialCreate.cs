using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWarehouse.Data.Migrations.Warehouse
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ImageId);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "stockcodes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Description = table.Column<string>(type: "mediumtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "supplycategories",
                columns: table => new
                {
                    SupplycategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.SupplycategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "transactioncodes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Description = table.Column<string>(type: "mediumtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "menucategories",
                columns: table => new
                {
                    MenucategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MenucategoryId);
                    table.ForeignKey(
                        name: "Menucategory_Image",
                        column: x => x.ImageId,
                        principalTable: "images",
                        principalColumn: "ImageId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    created_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_userId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    udated_userId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.SupplierId);
                    table.ForeignKey(
                        name: "Supplier_Image",
                        column: x => x.ImageId,
                        principalTable: "images",
                        principalColumn: "ImageId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    timestamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TransactionId);
                    table.ForeignKey(
                        name: "Transactions_TransactionCodes",
                        column: x => x.Code,
                        principalTable: "transactioncodes",
                        principalColumn: "Code");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "menuitems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    MenucategoryId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<ulong>(type: "bit(1)", nullable: false, defaultValueSql: "b'0'", comment: "Bit value represents boolean\n0 = true\n1 = false"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    created_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_userId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updated_userId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "MenuItem_Image",
                        column: x => x.ImageId,
                        principalTable: "images",
                        principalColumn: "ImageId");
                    table.ForeignKey(
                        name: "MenuItems_Menucategory",
                        column: x => x.MenucategoryId,
                        principalTable: "menucategories",
                        principalColumn: "MenucategoryId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "supplies",
                columns: table => new
                {
                    SupplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    SupplyCategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    created_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_userId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updated_userId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.SupplyId);
                    table.ForeignKey(
                        name: "Supplies_Suppliers",
                        column: x => x.SupplierId,
                        principalTable: "suppliers",
                        principalColumn: "SupplierId");
                    table.ForeignKey(
                        name: "Supplies_Supplycategories",
                        column: x => x.SupplyCategoryId,
                        principalTable: "supplycategories",
                        principalColumn: "SupplycategoryId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "transactionitems",
                columns: table => new
                {
                    TransactionItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    Price = table.Column<double>(type: "double(6,2)", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TransactionItemId);
                    table.ForeignKey(
                        name: "TransactionItems_MenuItems",
                        column: x => x.MenuItemId,
                        principalTable: "menuitems",
                        principalColumn: "MenuitemId");
                    table.ForeignKey(
                        name: "TransactionItems_Transactions",
                        column: x => x.TransactionId,
                        principalTable: "transactions",
                        principalColumn: "TransactionId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    SupplyId = table.Column<int>(type: "int", nullable: false),
                    created_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_userId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updated_userId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IngredientId);
                    table.ForeignKey(
                        name: "Ingredients_MenuItems",
                        column: x => x.MenuItemId,
                        principalTable: "menuitems",
                        principalColumn: "MenuitemId");
                    table.ForeignKey(
                        name: "Ingredients_Supplies",
                        column: x => x.SupplyId,
                        principalTable: "supplies",
                        principalColumn: "SupplyId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplyId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    Price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    timestamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.StockId);
                    table.ForeignKey(
                        name: "Stock_Stockcodes",
                        column: x => x.Code,
                        principalTable: "stockcodes",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "Stock_Supplies",
                        column: x => x.SupplyId,
                        principalTable: "supplies",
                        principalColumn: "SupplyId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "idImages_UNIQUE",
                table: "images",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idIngredients_UNIQUE",
                table: "ingredients",
                column: "IngredientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Ingredients_CreatedUser_idx",
                table: "ingredients",
                column: "created_userId");

            migrationBuilder.CreateIndex(
                name: "Ingredients_UpdatedUser_idx",
                table: "ingredients",
                column: "updated_userId");

            migrationBuilder.CreateIndex(
                name: "MenuItems_idx",
                table: "ingredients",
                column: "MenuitemId");

            migrationBuilder.CreateIndex(
                name: "Supplies_idx",
                table: "ingredients",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "idMenucategories_UNIQUE",
                table: "menucategories",
                column: "MenucategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menucategories_ImageId",
                table: "menucategories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "idMenuItems_UNIQUE",
                table: "menuitems",
                column: "MenuitemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuitems_ImageId",
                table: "menuitems",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "Menucategory_idx",
                table: "menuitems",
                column: "MenucategoryId");

            migrationBuilder.CreateIndex(
                name: "MenuItems_CreatedUser_idx",
                table: "menuitems",
                column: "created_userId");

            migrationBuilder.CreateIndex(
                name: "MenuItems_UpdatedUser_idx",
                table: "menuitems",
                column: "updated_userId");

            migrationBuilder.CreateIndex(
                name: "Code_UNIQUE",
                table: "stockcodes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idStock_UNIQUE",
                table: "stocks",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Stock_Stockcodes_idx",
                table: "stocks",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "Stock_Users_idx",
                table: "stocks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Supplies_idx1",
                table: "stocks",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "idSuppliers_UNIQUE",
                table: "suppliers",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_ImageId",
                table: "suppliers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "Suppliers_CreatedUser_idx",
                table: "suppliers",
                column: "created_userId");

            migrationBuilder.CreateIndex(
                name: "Suppliers_UpdatedUser_idx",
                table: "suppliers",
                column: "udated_userId");

            migrationBuilder.CreateIndex(
                name: "idSupplies_UNIQUE",
                table: "supplies",
                column: "SupplyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Supplies_CreatedUser_idx",
                table: "supplies",
                column: "created_userId");

            migrationBuilder.CreateIndex(
                name: "Supplies_Suppliers_idx",
                table: "supplies",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "Supplies_UpdatedUser_idx",
                table: "supplies",
                column: "updated_userId");

            migrationBuilder.CreateIndex(
                name: "Supplycategory_idx",
                table: "supplies",
                column: "SupplyCategoryId");

            migrationBuilder.CreateIndex(
                name: "idSupplycategory_UNIQUE",
                table: "supplycategories",
                column: "SupplycategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Name_UNIQUE",
                table: "supplycategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Code_UNIQUE1",
                table: "transactioncodes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idSales_UNIQUE",
                table: "transactionitems",
                column: "TransactionItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MenuItems_idx1",
                table: "transactionitems",
                column: "MenuitemId");

            migrationBuilder.CreateIndex(
                name: "Transactions_idx",
                table: "transactionitems",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "idTransactions_UNIQUE",
                table: "transactions",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Transactions_TransactionCodes_idx",
                table: "transactions",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "Transactions_Users_idx",
                table: "transactions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "transactionitems");

            migrationBuilder.DropTable(
                name: "stockcodes");

            migrationBuilder.DropTable(
                name: "supplies");

            migrationBuilder.DropTable(
                name: "menuitems");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "supplycategories");

            migrationBuilder.DropTable(
                name: "menucategories");

            migrationBuilder.DropTable(
                name: "transactioncodes");

            migrationBuilder.DropTable(
                name: "images");
        }
    }
}
