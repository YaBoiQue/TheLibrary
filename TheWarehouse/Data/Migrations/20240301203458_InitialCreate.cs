using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWarehouse.Data
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
                name: "Menucategories",
                columns: table => new
                {
                    MenucategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MenucategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    NormalizedName = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
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
                name: "suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    created_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.SupplierId);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "Supplycategories",
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
                name: "userlogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ProviderKey = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    UserId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    LastName = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    LockoutEndDateUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", maxLength: 6, nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "usertokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    LoginProvider = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Name = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Value = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
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
                    created_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "MenuItems_Menucategory",
                        column: x => x.MenucategoryId,
                        principalTable: "Menucategories",
                        principalColumn: "MenucategoryId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "roleclaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roleclaims_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id");
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
                    updated_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                        principalTable: "Supplycategories",
                        principalColumn: "SupplycategoryId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<string>(type: "varchar(128)", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    UsersId = table.Column<string>(type: "varchar(128)", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Code = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    timestamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TransactionId);
                    table.ForeignKey(
                        name: "Transaction_Users",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Transactions_TransactionCodes",
                        column: x => x.Code,
                        principalTable: "transactioncodes",
                        principalColumn: "Code");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "userclaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userclaims_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "userroles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(128)", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    RoleId = table.Column<string>(type: "varchar(128)", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.UserId, x.RoleId })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_userroles_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userroles_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    updated_ts = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IngredientId);
                    table.ForeignKey(
                        name: "Ingredients_MenuItems",
                        column: x => x.MenuItemId,
                        principalTable: "menuitems",
                        principalColumn: "MenuItemId");
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
                    UserId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ReceiptId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "Stock_Users",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
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
                        principalColumn: "MenuItemId");
                    table.ForeignKey(
                        name: "TransactionItems_Transactions",
                        column: x => x.TransactionId,
                        principalTable: "transactions",
                        principalColumn: "TransactionId");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "idIngredients_UNIQUE",
                table: "ingredients",
                column: "IngredientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MenuItems_idx",
                table: "ingredients",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "Supplies_idx",
                table: "ingredients",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "idMenucategories_UNIQUE",
                table: "Menucategories",
                column: "MenucategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idMenuItems_UNIQUE",
                table: "menuitems",
                column: "MenuItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Menucategory_idx",
                table: "menuitems",
                column: "MenucategoryId");

            migrationBuilder.CreateIndex(
                name: "Claim_Role_idx",
                table: "roleclaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

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
                name: "idSupplies_UNIQUE",
                table: "supplies",
                column: "SupplyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Supplies_Suppliers_idx",
                table: "supplies",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "Supplycategory_idx",
                table: "supplies",
                column: "SupplyCategoryId");

            migrationBuilder.CreateIndex(
                name: "idSupplycategory_UNIQUE",
                table: "Supplycategories",
                column: "SupplycategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Name_UNIQUE",
                table: "Supplycategories",
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
                column: "MenuItemId");

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
                name: "Transaction_Users_idx",
                table: "transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Transactions_TransactionCodes_idx",
                table: "transactions",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "Claim_User_idx",
                table: "userclaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Login_User_idx",
                table: "userlogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IdentityRole_Users",
                table: "userroles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "Token_User_idx",
                table: "usertokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "roleclaims");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "transactionitems");

            migrationBuilder.DropTable(
                name: "userclaims");

            migrationBuilder.DropTable(
                name: "userlogins");

            migrationBuilder.DropTable(
                name: "userroles");

            migrationBuilder.DropTable(
                name: "usertokens");

            migrationBuilder.DropTable(
                name: "stockcodes");

            migrationBuilder.DropTable(
                name: "supplies");

            migrationBuilder.DropTable(
                name: "menuitems");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "Supplycategories");

            migrationBuilder.DropTable(
                name: "Menucategories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "transactioncodes");
        }
    }
}
