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
        => optionsBuilder.UseMySql(/**/"server=localhost;port=3306;database=warehousedb;user=dev;password=KnightDev7601*"/*
            "server=host.docker.internal;port=3306;database=warehousedb;user=dev;password=KnightDev7601*"/**/, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PRIMARY");

            entity.ToTable("ingredients");

            entity.HasIndex(e => e.CreatedUserId, "Ingredients_CreatedUser_idx");

            entity.HasIndex(e => e.UpdatedUserId, "Ingredients_UpdatedUser_idx");

            entity.HasIndex(e => e.MenuItemId, "MenuItems_idx");

            entity.HasIndex(e => e.SupplyId, "Supplies_idx");

            entity.HasIndex(e => e.IngredientId, "idIngredients_UNIQUE").IsUnique();

            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.CreatedUserId)
                .HasColumnName("created_userId")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");
            entity.Property(e => e.UpdatedUserId)
                .HasColumnName("updated_userId")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

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

            entity.ToTable("menucategories");

            entity.HasIndex(e => e.MenucategoryId, "idMenucategories_UNIQUE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Menuitem>(entity =>
        {
            entity.HasKey(e => e.MenuitemId).HasName("PRIMARY");

            entity.ToTable("menuitems");

            entity.HasIndex(e => e.CreatedUserId, "MenuItems_CreatedUser_idx");

            entity.HasIndex(e => e.UpdatedUserId, "MenuItems_UpdatedUser_idx");

            entity.HasIndex(e => e.MenucategoryId, "Menucategory_idx");

            entity.HasIndex(e => e.MenuitemId, "idMenuItems_UNIQUE").IsUnique();

            entity.Property(e => e.Active)
                .HasDefaultValueSql("b'0'")
                .HasComment("Bit value represents boolean\n0 = true\n1 = false")
                .HasColumnType("bit(1)")
                .HasSentinel(true);
            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.CreatedUserId)
                .HasColumnName("created_userId")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(5, 2);
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");
            entity.Property(e => e.UpdatedUserId)
                .HasColumnName("updated_userId")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            entity.HasOne(d => d.Menucategory).WithMany(p => p.Menuitems)
                .HasForeignKey(d => d.MenucategoryId)
                .HasConstraintName("MenuItems_Menucategory");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PRIMARY");

            entity.ToTable("stocks");

            entity.HasIndex(e => e.StockreceiptId, "Stock_Stockreceipt_idx");

            entity.HasIndex(e => e.Code, "Stock_Stockcodes_idx");

            entity.HasIndex(e => e.UserId, "Stock_Users_idx");

            entity.HasIndex(e => e.SupplyId, "Supplies_idx1");

            entity.HasIndex(e => e.StockId, "idStock_UNIQUE").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Count).HasDefaultValueSql("'1'");
            entity.Property(e => e.Price).HasPrecision(6, 2);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            entity.HasOne(e => e.Stockreceipt).WithMany(p => p.Stocks)
                .HasForeignKey(e => e.StockreceiptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Stock_Stockreceipt");

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

            entity.ToTable("stockcodes");

            entity.HasIndex(e => e.Code, "Code_UNIQUE").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Description).HasColumnType("mediumtext");
        });

        modelBuilder.Entity<Stockreceipt>(entity =>
        {
            entity.HasKey(e => e.StockreceiptId).HasName("PRIMARY");

            entity.ToTable("stockreceipts");

            entity.HasIndex(e => e.StockreceiptId, "StockreceiptId_UNIQUE").IsUnique();

            entity.HasIndex(e => e.SupplierId, "Stockreceipt_Supplier_idx");

            entity.HasIndex(e => e.UserId, "Stock_Users_idx");


            entity.Property(e => e.ImageName).HasMaxLength(255);

            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.DateTimePurchased)
                .HasColumnType("datetime")
                .HasColumnName("datetimepurchased");
            entity.Property(e => e.UserId)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            entity.HasOne(e => e.Supplier).WithMany(s => s.Stockreceipts)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Stockreceipt_Supplier");

        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.HasIndex(e => e.CreatedUserId, "Suppliers_CreatedUser_idx");

            entity.HasIndex(e => e.UpdatedUserId, "Suppliers_UpdatedUser_idx");

            entity.HasIndex(e => e.SupplierId, "idSuppliers_UNIQUE").IsUnique();

            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.CreatedUserId)
                .HasColumnName("created_userId")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.UpdatedUserId)
                .HasColumnName("udated_userId")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.SupplyId).HasName("PRIMARY");

            entity.ToTable("supplies");

            entity.HasIndex(e => e.CreatedUserId, "Supplies_CreatedUser_idx");

            entity.HasIndex(e => e.SupplierId, "Supplies_Suppliers_idx");

            entity.HasIndex(e => e.UpdatedUserId, "Supplies_UpdatedUser_idx");

            entity.HasIndex(e => e.SupplyCategoryId, "Supplycategory_idx");

            entity.HasIndex(e => e.SupplyId, "idSupplies_UNIQUE").IsUnique();

            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.CreatedUserId)
                .HasColumnName("created_userId")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");
            entity.Property(e => e.UpdatedUserId)
                .HasColumnName("updated_userId")
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

            entity.ToTable("supplycategories");

            entity.HasIndex(e => e.Name, "Name_UNIQUE").IsUnique();

            entity.HasIndex(e => e.SupplycategoryId, "idSupplycategory_UNIQUE").IsUnique();

            entity.Property(e => e.SupplycategoryId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transactions");

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

            entity.ToTable("transactioncodes");

            entity.HasIndex(e => e.Code, "Code_UNIQUE1").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Description).HasColumnType("mediumtext");
        });

        modelBuilder.Entity<Transactionitem>(entity =>
        {
            entity.HasKey(e => e.TransactionItemId).HasName("PRIMARY");

            entity.ToTable("transactionitems");

            entity.HasIndex(e => e.MenuItemId, "MenuItems_idx1");

            entity.HasIndex(e => e.TransactionId, "Transactions_idx");

            entity.HasIndex(e => e.TransactionItemId, "idSales_UNIQUE").IsUnique();

            entity.Property(e => e.Quantity).HasDefaultValueSql("'1'");
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

public DbSet<TheWarehouse.Models.Stockreceipt> Stockreceipt { get; set; } = default!;
}
