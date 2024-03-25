using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using TheWarehouse.Models;

namespace TheWarehouse.Data;

public partial class WarehouseDbContext : DbContext
{
    public WarehouseDbContext()
    {
    }

    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Menucategory> Menucategories { get; set; }

    public virtual DbSet<Menuitem> Menuitems { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Stockcode> Stockcodes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<Supplycategory> Supplycategories { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transactioncode> Transactioncodes { get; set; }

    public virtual DbSet<Transactionitem> Transactionitems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql(/*"server=localhost;port=3306;database=warehousedb;user=dev;password=KnightDev7601*"*/
            "server=host.docker.internal;port=3306;database=warehousedb;user=dev;password=KnightDev7601*", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PRIMARY");

            entity
                .ToTable("ingredients")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.MenuItemId, "MenuItems_idx");

            entity.HasIndex(e => e.SupplyId, "Supplies_idx");

            entity.HasIndex(e => e.IngredientId, "idIngredients_UNIQUE").IsUnique();

            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");

            entity.HasOne(d => d.MenuItem).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ingredients_MenuItems");

            entity.HasOne(d => d.Supply).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ingredients_Supplies");
        });

        modelBuilder.Entity<Menucategory>(entity =>
        {
            entity.HasKey(e => e.MenucategoryId).HasName("PRIMARY");

            entity
                .ToTable("menucategories")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "MenuCategories_Users_idx");

            entity.HasIndex(e => e.MenucategoryId, "idMenucategories_UNIQUE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Menuitem>(entity =>
        {
            entity.HasKey(e => e.MenuItemId).HasName("PRIMARY");

            entity
                .ToTable("menuitems")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "MenuItems_Users_idx");

            entity.HasIndex(e => e.MenucategoryId, "Menucategory_idx");

            entity.HasIndex(e => e.MenuItemId, "idMenuItems_UNIQUE").IsUnique();

            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(5, 2);
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            entity.HasOne(d => d.Menucategory).WithMany(p => p.Menuitems)
                .HasForeignKey(d => d.MenucategoryId)
                .HasConstraintName("MenuItems_Menucategory");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PRIMARY");

            entity
                .ToTable("stocks")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Code, "Stock_Stockcodes_idx");

            entity.HasIndex(e => e.SupplyId, "Supplies_idx1");

            entity.HasIndex(e => e.StockId, "idStock_UNIQUE").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Count).HasDefaultValueSql("'1'");
            entity.Property(e => e.Price).HasPrecision(6, 2);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Stock_Stockcodes");

            entity.HasOne(d => d.Supply).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Stock_Supplies");
        });

        modelBuilder.Entity<Stockcode>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity
                .ToTable("stockcodes")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Code, "Code_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserId, "StockCodes_Users_idx");

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Description).HasColumnType("mediumtext");
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity
                .ToTable("suppliers")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "Suppliers_Users_idx");

            entity.HasIndex(e => e.SupplierId, "idSuppliers_UNIQUE").IsUnique();

            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.SupplyId).HasName("PRIMARY");

            entity
                .ToTable("supplies")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.SupplierId, "Supplies_Suppliers_idx");

            entity.HasIndex(e => e.UserId, "Supplies_Users_idx");

            entity.HasIndex(e => e.SupplyCategoryId, "Supplycategory_idx");

            entity.HasIndex(e => e.SupplyId, "idSupplies_UNIQUE").IsUnique();

            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("Supplies_Suppliers");

            entity.HasOne(d => d.SupplyCategory).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.SupplyCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Supplies_Supplycategories");
        });

        modelBuilder.Entity<Supplycategory>(entity =>
        {
            entity.HasKey(e => e.SupplycategoryId).HasName("PRIMARY");

            entity
                .ToTable("supplycategories")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Name, "Name_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserId, "SupplyCategories_Users_idx");

            entity.HasIndex(e => e.SupplycategoryId, "idSupplycategory_UNIQUE").IsUnique();

            entity.Property(e => e.SupplycategoryId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity
                .ToTable("transactions")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Code, "Transactions_TransactionCodes_idx");

            entity.HasIndex(e => e.UserId, "Transactions_Users_idx");

            entity.HasIndex(e => e.TransactionId, "idTransactions_UNIQUE").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Code)
                .HasConstraintName("Transactions_TransactionCodes");
        });

        modelBuilder.Entity<Transactioncode>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity
                .ToTable("transactioncodes")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Code, "Code_UNIQUE1").IsUnique();

            entity.HasIndex(e => e.UserId, "Transaction_Codes_Users_idx");

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Description).HasColumnType("mediumtext");
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Transactionitem>(entity =>
        {
            entity.HasKey(e => e.TransactionItemId).HasName("PRIMARY");

            entity
                .ToTable("transactionitems")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.MenuItemId, "MenuItems_idx1");

            entity.HasIndex(e => e.TransactionId, "Transactions_idx");

            entity.HasIndex(e => e.TransactionItemId, "idSales_UNIQUE").IsUnique();

            entity.Property(e => e.Count).HasDefaultValueSql("'1'");
            entity.Property(e => e.Price).HasColumnType("double(6,2)");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.MenuItem).WithMany(p => p.Transactionitems)
                .HasForeignKey(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TransactionItems_MenuItems");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Transactionitems)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TransactionItems_Transactions");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
