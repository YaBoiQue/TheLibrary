﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheWarehouse.Data;

#nullable disable

namespace TheWarehouse.Data
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240301203458_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb3_general_ci")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb3");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RoleId" }, "Claim_Role_idx");

                    b.ToTable("roleclaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "Claim_User_idx");

                    b.ToTable("userclaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasIndex(new[] { "UserId" }, "Login_User_idx");

                    b.ToTable("userlogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(128)");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "RoleId" }, "IdentityRole_Users");

                    b.ToTable("userroles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasIndex(new[] { "UserId" }, "Token_User_idx");

                    b.ToTable("usertokens", (string)null);
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UsersId")
                        .HasColumnType("varchar(128)");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("TheWarehouse.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("SupplyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("IngredientId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MenuItemId" }, "MenuItems_idx");

                    b.HasIndex(new[] { "SupplyId" }, "Supplies_idx");

                    b.HasIndex(new[] { "IngredientId" }, "idIngredients_UNIQUE")
                        .IsUnique();

                    b.ToTable("ingredients", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Menucategory", b =>
                {
                    b.Property<int>("MenucategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MenucategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("MenucategoryId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MenucategoryId" }, "idMenucategories_UNIQUE")
                        .IsUnique();

                    b.ToTable("Menucategories", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Menuitem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("MenucategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<decimal?>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("UpdatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("MenuItemId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MenucategoryId" }, "Menucategory_idx");

                    b.HasIndex(new[] { "MenuItemId" }, "idMenuItems_UNIQUE")
                        .IsUnique();

                    b.ToTable("menuitems", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StockId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'1'");

                    b.Property<decimal?>("Price")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("ReceiptId")
                        .HasColumnType("int");

                    b.Property<int>("SupplyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("StockId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Code" }, "Stock_Stockcodes_idx");

                    b.HasIndex(new[] { "UserId" }, "Stock_Users_idx");

                    b.HasIndex(new[] { "SupplyId" }, "Supplies_idx1");

                    b.HasIndex(new[] { "StockId" }, "idStock_UNIQUE")
                        .IsUnique();

                    b.ToTable("stocks", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Stockcode", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Description")
                        .HasColumnType("mediumtext");

                    b.HasKey("Code")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Code" }, "Code_UNIQUE")
                        .IsUnique();

                    b.ToTable("stockcodes", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime>("UpdatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("SupplierId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "SupplierId" }, "idSuppliers_UNIQUE")
                        .IsUnique();

                    b.ToTable("suppliers", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Supply", b =>
                {
                    b.Property<int>("SupplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SupplyId"));

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("SupplyCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("SupplyId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "SupplierId" }, "Supplies_Suppliers_idx");

                    b.HasIndex(new[] { "SupplyCategoryId" }, "Supplycategory_idx");

                    b.HasIndex(new[] { "SupplyId" }, "idSupplies_UNIQUE")
                        .IsUnique();

                    b.ToTable("supplies", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Supplycategory", b =>
                {
                    b.Property<int>("SupplycategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("SupplycategoryId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Name" }, "Name_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "SupplycategoryId" }, "idSupplycategory_UNIQUE")
                        .IsUnique();

                    b.ToTable("Supplycategories", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<string>("Code")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("TransactionId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "Transaction_Users_idx");

                    b.HasIndex(new[] { "Code" }, "Transactions_TransactionCodes_idx");

                    b.HasIndex(new[] { "TransactionId" }, "idTransactions_UNIQUE")
                        .IsUnique();

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Transactioncode", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Description")
                        .HasColumnType("mediumtext");

                    b.HasKey("Code")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Code" }, "Code_UNIQUE1")
                        .IsUnique();

                    b.ToTable("transactioncodes", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.Transactionitem", b =>
                {
                    b.Property<int>("TransactionItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TransactionItemId"));

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double(6,2)");

                    b.Property<DateTime?>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("TransactionItemId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MenuItemId" }, "MenuItems_idx1");

                    b.HasIndex(new[] { "TransactionId" }, "Transactions_idx");

                    b.HasIndex(new[] { "TransactionItemId" }, "idSales_UNIQUE")
                        .IsUnique();

                    b.ToTable("transactionitems", (string)null);
                });

            modelBuilder.Entity("TheWarehouse.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LockoutEndDateUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("TheWarehouse.Models.Role", null)
                        .WithMany("Roleclaims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TheWarehouse.Models.User", null)
                        .WithMany("Userclaims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("TheWarehouse.Models.Role", null)
                        .WithMany("Userroles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheWarehouse.Models.User", null)
                        .WithMany("Userroles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("TheWarehouse.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheWarehouse.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheWarehouse.Models.Ingredient", b =>
                {
                    b.HasOne("TheWarehouse.Models.Menuitem", "MenuItem")
                        .WithMany("Ingredients")
                        .HasForeignKey("MenuItemId")
                        .IsRequired()
                        .HasConstraintName("Ingredients_MenuItems");

                    b.HasOne("TheWarehouse.Models.Supply", "Supply")
                        .WithMany("Ingredients")
                        .HasForeignKey("SupplyId")
                        .IsRequired()
                        .HasConstraintName("Ingredients_Supplies");

                    b.Navigation("MenuItem");

                    b.Navigation("Supply");
                });

            modelBuilder.Entity("TheWarehouse.Models.Menuitem", b =>
                {
                    b.HasOne("TheWarehouse.Models.Menucategory", "Menucategory")
                        .WithMany("Menuitems")
                        .HasForeignKey("MenucategoryId")
                        .HasConstraintName("MenuItems_Menucategory");

                    b.Navigation("Menucategory");
                });

            modelBuilder.Entity("TheWarehouse.Models.Stock", b =>
                {
                    b.HasOne("TheWarehouse.Models.Stockcode", "CodeNavigation")
                        .WithMany("Stocks")
                        .HasForeignKey("Code")
                        .IsRequired()
                        .HasConstraintName("Stock_Stockcodes");

                    b.HasOne("TheWarehouse.Models.Supply", "Supply")
                        .WithMany("Stocks")
                        .HasForeignKey("SupplyId")
                        .IsRequired()
                        .HasConstraintName("Stock_Supplies");

                    b.HasOne("TheWarehouse.Models.User", "User")
                        .WithMany("Stocks")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("Stock_Users");

                    b.Navigation("CodeNavigation");

                    b.Navigation("Supply");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheWarehouse.Models.Supply", b =>
                {
                    b.HasOne("TheWarehouse.Models.Supplier", "Supplier")
                        .WithMany("Supplies")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("Supplies_Suppliers");

                    b.HasOne("TheWarehouse.Models.Supplycategory", "Supplycategory")
                        .WithMany("Supplies")
                        .HasForeignKey("SupplyCategoryId")
                        .IsRequired()
                        .HasConstraintName("Supplies_Supplycategories");

                    b.Navigation("Supplier");

                    b.Navigation("Supplycategory");
                });

            modelBuilder.Entity("TheWarehouse.Models.Transaction", b =>
                {
                    b.HasOne("TheWarehouse.Models.Transactioncode", "CodeNavigation")
                        .WithMany("Transactions")
                        .HasForeignKey("Code")
                        .HasConstraintName("Transactions_TransactionCodes");

                    b.HasOne("TheWarehouse.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("Transaction_Users");

                    b.Navigation("CodeNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheWarehouse.Models.Transactionitem", b =>
                {
                    b.HasOne("TheWarehouse.Models.Menuitem", "MenuItem")
                        .WithMany("Transactionitems")
                        .HasForeignKey("MenuItemId")
                        .IsRequired()
                        .HasConstraintName("TransactionItems_MenuItems");

                    b.HasOne("TheWarehouse.Models.Transaction", "Transaction")
                        .WithMany("Transactionitems")
                        .HasForeignKey("TransactionId")
                        .IsRequired()
                        .HasConstraintName("TransactionItems_Transactions");

                    b.Navigation("MenuItem");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("TheWarehouse.Models.Menucategory", b =>
                {
                    b.Navigation("Menuitems");
                });

            modelBuilder.Entity("TheWarehouse.Models.Menuitem", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Transactionitems");
                });

            modelBuilder.Entity("TheWarehouse.Models.Role", b =>
                {
                    b.Navigation("Roleclaims");

                    b.Navigation("Userroles");
                });

            modelBuilder.Entity("TheWarehouse.Models.Stockcode", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("TheWarehouse.Models.Supplier", b =>
                {
                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("TheWarehouse.Models.Supply", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("TheWarehouse.Models.Supplycategory", b =>
                {
                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("TheWarehouse.Models.Transaction", b =>
                {
                    b.Navigation("Transactionitems");
                });

            modelBuilder.Entity("TheWarehouse.Models.Transactioncode", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("TheWarehouse.Models.User", b =>
                {
                    b.Navigation("Stocks");

                    b.Navigation("Transactions");

                    b.Navigation("Userclaims");

                    b.Navigation("Userroles");
                });
#pragma warning restore 612, 618
        }
    }
}
