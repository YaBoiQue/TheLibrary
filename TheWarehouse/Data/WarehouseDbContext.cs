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

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Inventorycode> Inventorycodes { get; set; }

    public virtual DbSet<Menuitem> Menuitems { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<Supplytype> Supplytypes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transactioncode> Transactioncodes { get; set; }

    public virtual DbSet<Transactionitem> Transactionitems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategories).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.IdCategories, "idCategories_UNIQUE").IsUnique();

            entity.Property(e => e.IdCategories).HasColumnName("idCategories");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployees).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.IdEmployees, "idEmployees_UNIQUE").IsUnique();

            entity.Property(e => e.IdEmployees).HasColumnName("idEmployees");
            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.FirstName).HasMaxLength(45);
            entity.Property(e => e.LastName).HasMaxLength(45);
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IdIngredients).HasName("PRIMARY");

            entity.ToTable("ingredients");

            entity.HasIndex(e => e.MenuItemId, "MenuItems_idx");

            entity.HasIndex(e => e.SupplyId, "Supplies_idx");

            entity.HasIndex(e => e.IdIngredients, "idIngredients_UNIQUE").IsUnique();

            entity.Property(e => e.IdIngredients).HasColumnName("idIngredients");
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

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.IdInventory).HasName("PRIMARY");

            entity.ToTable("inventory");

            entity.HasIndex(e => e.EmployeeId, "Employees_idx");

            entity.HasIndex(e => e.Code, "Inventory_InventoryCodes_idx");

            entity.HasIndex(e => e.ReceiptId, "Inventory_Receipts_idx");

            entity.HasIndex(e => e.SupplyId, "Supplies_idx");

            entity.HasIndex(e => e.IdInventory, "idInventory_UNIQUE").IsUnique();

            entity.Property(e => e.IdInventory).HasColumnName("idInventory");
            entity.Property(e => e.Amount).HasDefaultValueSql("'1'");
            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(6, 2);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Inventory_InventoryCodes");

            entity.HasOne(d => d.Employee).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Inventory_Employees");

            entity.HasOne(d => d.Receipt).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ReceiptId)
                .HasConstraintName("Inventory_Receipts");

            entity.HasOne(d => d.Supply).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Inventory_Supplies");
        });

        modelBuilder.Entity<Inventorycode>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PRIMARY");

            entity.ToTable("inventorycodes");

            entity.HasIndex(e => e.Name, "Code_UNIQUE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Description).HasColumnType("mediumtext");
        });

        modelBuilder.Entity<Menuitem>(entity =>
        {
            entity.HasKey(e => e.IdMenuItems).HasName("PRIMARY");

            entity.ToTable("menuitems");

            entity.HasIndex(e => e.CategoryId, "Category_idx");

            entity.HasIndex(e => e.IdMenuItems, "idMenuItems_UNIQUE").IsUnique();

            entity.Property(e => e.IdMenuItems).HasColumnName("idMenuItems");
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

            entity.HasOne(d => d.Category).WithMany(p => p.Menuitems)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("MenuItems_Category");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.IdReceipts).HasName("PRIMARY");

            entity.ToTable("receipts");

            entity.HasIndex(e => e.EmployeeId, "Receipts_Employees_idx");

            entity.HasIndex(e => e.IdReceipts, "idReceipts_UNIQUE").IsUnique();

            entity.Property(e => e.IdReceipts).HasColumnName("idReceipts");
            entity.Property(e => e.ReceiptNum).HasMaxLength(45);
            entity.Property(e => e.Store).HasMaxLength(45);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.Total).HasColumnType("double(6,2)");

            entity.HasOne(d => d.Employee).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("Receipts_Employees");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSuppliers).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.HasIndex(e => e.IdSuppliers, "idSuppliers_UNIQUE").IsUnique();

            entity.Property(e => e.IdSuppliers).HasColumnName("idSuppliers");
            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.IdSupplies).HasName("PRIMARY");

            entity.ToTable("supplies");

            entity.HasIndex(e => e.SupplierId, "Supplies_Suppliers_idx");

            entity.HasIndex(e => e.TypeId, "SupplyType_idx");

            entity.HasIndex(e => e.IdSupplies, "idSupplies_UNIQUE").IsUnique();

            entity.Property(e => e.IdSupplies).HasColumnName("idSupplies");
            entity.Property(e => e.CreatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_ts");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.TypeId).HasMaxLength(45);
            entity.Property(e => e.UpdatedTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_ts");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("Supplies_Suppliers");

            entity.HasOne(d => d.Type).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Supplies_SupplyType");
        });

        modelBuilder.Entity<Supplytype>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PRIMARY");

            entity.ToTable("supplytype");

            entity.HasIndex(e => e.Name, "idSupplyType_UNIQUE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.IdTransactions).HasName("PRIMARY");

            entity.ToTable("transactions");

            entity.HasIndex(e => e.EmployeeId, "Employees_idx");

            entity.HasIndex(e => e.Code, "Transactions_TransactionCodes_idx");

            entity.HasIndex(e => e.IdTransactions, "idTransactions_UNIQUE").IsUnique();

            entity.Property(e => e.IdTransactions).HasColumnName("idTransactions");
            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Code)
                .HasConstraintName("Transactions_TransactionCodes");

            entity.HasOne(d => d.Employee).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Transactions_Employees");
        });

        modelBuilder.Entity<Transactioncode>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PRIMARY");

            entity.ToTable("transactioncodes");

            entity.HasIndex(e => e.Name, "Code_UNIQUE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Description).HasColumnType("mediumtext");
        });

        modelBuilder.Entity<Transactionitem>(entity =>
        {
            entity.HasKey(e => e.IdTransactionItems).HasName("PRIMARY");

            entity.ToTable("transactionitems");

            entity.HasIndex(e => e.MenuItemId, "MenuItems_idx");

            entity.HasIndex(e => e.TransactionId, "Transactions_idx");

            entity.HasIndex(e => e.IdTransactionItems, "idSales_UNIQUE").IsUnique();

            entity.Property(e => e.IdTransactionItems).HasColumnName("idTransactionItems");
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
