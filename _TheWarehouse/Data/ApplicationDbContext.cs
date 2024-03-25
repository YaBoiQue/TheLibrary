using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using TheWarehouse.Models;

namespace TheWarehouse.Data;

public partial class ApplicationDbContext : IdentityDbContext<User, Role, string>// Userclaim, Userrole, Userlogin, Roleclaim, Usertoken>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Menucategory> Menucategories { get; set; }

    public virtual DbSet<Menuitem> Menuitems { get; set; }

    public new virtual DbSet<Role> Roles { get; set; }

    //public virtual DbSet<Roleclaim> Roleclaims { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Stockcode> Stockcodes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<Supplycategory> Supplycategories { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transactioncode> Transactioncodes { get; set; }

    public virtual DbSet<Transactionitem> Transactionitems { get; set; }

    public new virtual DbSet<User> Users { get; set; }

    //public virtual DbSet<Userclaim> Userclaims { get; set; }

    //public virtual DbSet<Userlogin> Userlogins { get; set; }

    //public virtual DbSet<Userrole> Userroles { get; set; }

    //public virtual DbSet<Usertoken> Usertokens { get; set; }

    // VIEWS
    public virtual DbSet<MenuPriceTotal> Menupricetotals { get; set; }
    

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=quintenk;password=Knights2;database=warehouseDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PRIMARY");

            entity.ToTable("ingredients");

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

            entity.ToTable("Menucategories");

            entity.HasIndex(e => e.MenucategoryId, "idMenucategories_UNIQUE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Menuitem>(entity =>
        {
            entity.HasKey(e => e.MenuItemId).HasName("PRIMARY");

            entity.ToTable("menuitems");

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

            entity.HasOne(d => d.Menucategory).WithMany(p => p.Menuitems)
                .HasForeignKey(d => d.MenucategoryId)
                .HasConstraintName("MenuItems_Menucategory");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);

            entity.HasMany(r => r.Userroles);
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roleclaims");

            entity.HasIndex(e => e.RoleId, "Claim_Role_idx");

            entity.Property(e => e.RoleId).HasMaxLength(128);

            //entity.HasOne(d => d.Role).WithMany(p => p.Roleclaims)
              //  .HasForeignKey(d => d.RoleId)
              //  .HasConstraintName("Claim_Role");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PRIMARY");

            entity.ToTable("stocks");

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
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Stock_Stockcodes");

            entity.HasOne(d => d.Supply).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Stock_Supplies");

            entity.HasOne(d => d.User).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Stock_Users");
        });

        modelBuilder.Entity<Stockcode>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity.ToTable("stockcodes");

            entity.HasIndex(e => e.Code, "Code_UNIQUE").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Description).HasColumnType("mediumtext");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("suppliers");

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
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.SupplyId).HasName("PRIMARY");

            entity.ToTable("supplies");

            entity.HasIndex(e => e.SupplierId, "Supplies_Suppliers_idx");

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

            entity.HasOne(d => d.Supplycategory).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.SupplyCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Supplies_Supplycategories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("Supplies_Suppliers");
        });

        modelBuilder.Entity<Supplycategory>(entity =>
        {
            entity.HasKey(e => e.SupplycategoryId).HasName("PRIMARY");

            entity.ToTable("Supplycategories");

            entity.HasIndex(e => e.Name, "Name_UNIQUE").IsUnique();

            entity.HasIndex(e => e.SupplycategoryId, "idSupplycategory_UNIQUE").IsUnique();

            entity.Property(e => e.SupplycategoryId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transactions");

            entity.HasIndex(e => e.UserId, "Transaction_Users_idx");

            entity.HasIndex(e => e.Code, "Transactions_TransactionCodes_idx");

            entity.HasIndex(e => e.TransactionId, "idTransactions_UNIQUE").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Code)
                .HasConstraintName("Transactions_TransactionCodes");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Transaction_Users");
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

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEnd).HasMaxLength(6);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);

            /*
            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<IdentityUserRole<string>>(
                    "IdentityUserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("IdentityRole_Users"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("ApplicationUser_Roles"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("userroles");
                        j.HasIndex(new[] { "RoleId" }, "IdentityRole_Users");
                        //j.IndexerProperty<string>("UserRole_UserId").HasMaxLength(128);
                        //j.IndexerProperty<string>("UserRole_RoleId").HasMaxLength(128);
                        
                    });
            */

            entity.HasMany(u => u.Userroles);
        });

        
        modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("userclaims");

            entity.HasIndex(e => e.UserId, "Claim_User_idx");

            entity.Property(e => e.UserId).HasMaxLength(128);

            //entity.HasOne(d => d.User).WithMany(p => p.Userclaims)
              //  .HasForeignKey(d => d.UserId)
              //  .HasConstraintName("Claim_User");
        });
        

        
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("userlogins");

            entity.HasIndex(e => e.UserId, "Login_User_idx");

            entity.Property(e => e.UserId).HasMaxLength(128);

            //entity.HasOne(d => d.User).WithMany()
              //  .HasForeignKey(d => d.UserId)
              //  .OnDelete(DeleteBehavior.ClientSetNull)
              //  .HasConstraintName("Login_User");
        });
        

        
        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usertokens");

            entity.HasIndex(e => e.UserId, "Token_User_idx");

            entity.Property(e => e.UserId).HasMaxLength(128);

            //entity.HasOne(d => d.User).WithMany()
              //  .HasForeignKey(d => d.UserId)
              //  .OnDelete(DeleteBehavior.ClientSetNull)
              //  .HasConstraintName("Token_User");
        });


        
        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey("UserId", "RoleId")
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            entity.ToTable("userroles");
            entity.HasIndex(new[] { "RoleId" }, "IdentityRole_Users");
            //entity.IndexerProperty<string>("UserRole_UserId").HasMaxLength(128);
            //entity.IndexerProperty<string>("UserRole_RoleId").HasMaxLength(128);
            /*
            entity
                .HasNoKey()
                .ToTable("userroles");

            entity.HasIndex(u => u.UserId, "UserRole_User_idx");
            entity.HasIndex(u => u.RoleId, "UserRole_Role_idx");

            entity.Property(u => u.UserId).HasMaxLength(128);
            entity.Property(u => u.RoleId).HasMaxLength(128);
            */
        });

        modelBuilder.Entity<MenuPriceTotal>(entity =>
        {
            entity.HasKey("MenuitemId")
                .HasName("PRIMARY");
            entity.ToView("MenuPriceTotal");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
