using System;
using System.Collections.Generic;
using IdentityController.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace IdentityController.Data;

public partial class ApplicationDbContext : IdentityDbContext<User, Role, string>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Role>(entity =>
        {
            /*
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);
            */

            // Primary key
            entity.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            entity.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            entity.ToTable("AspNetRoles");

            // A concurrency token for use with the optimistic concurrency checking
            entity.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            entity.Property(u => u.Name).HasMaxLength(256);
            entity.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            entity.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            entity.HasMany<IdentityRoleClaim<string>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
        });

        modelBuilder.Entity<User>(entity =>
        {
            /*
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Userrole",
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
                        j.IndexerProperty<string>("UserId").HasMaxLength(128);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                    });
            */

            // Primary key
            entity.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            entity.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            entity.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

            // Maps to the AspNetUsers table
            entity.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            entity.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            entity.Property(u => u.UserName).HasMaxLength(256);
            entity.Property(u => u.NormalizedUserName).HasMaxLength(256);
            entity.Property(u => u.Email).HasMaxLength(256);
            entity.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            entity.HasMany<IdentityUserClaim<string>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            entity.HasMany<IdentityUserLogin<string>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            entity.HasMany<IdentityUserToken<string>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            entity.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(b =>
        {
            // Primary key
            b.HasKey(uc => uc.Id);

            // Maps to the AspNetUserClaims table
            b.ToTable("AspNetUserClaims");
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            // Composite primary key consisting of the LoginProvider and the key to use
            // with that provider
            b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

            // Limit the size of the composite key columns due to common DB restrictions
            b.Property(l => l.LoginProvider).HasMaxLength(128);
            b.Property(l => l.ProviderKey).HasMaxLength(128);

            // Maps to the AspNetUserLogins table
            b.ToTable("AspNetUserLogins");
        });

        modelBuilder.Entity<IdentityUserToken<string>>(b =>
        {
            // Composite primary key consisting of the UserId, LoginProvider and Name
            b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            // Limit the size of the composite key columns due to common DB restrictions
            b.Property(t => t.LoginProvider).HasMaxLength(128);
            b.Property(t => t.Name).HasMaxLength(128);

            // Maps to the AspNetUserTokens table
            b.ToTable("AspNetUserTokens");
        });


        modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
        {
            // Primary key
            b.HasKey(rc => rc.Id);

            // Maps to the AspNetRoleClaims table
            b.ToTable("AspNetRoleClaims");
        });

        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            // Primary key
            b.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            b.ToTable("AspNetUserRoles");
        });

        base.OnModelCreating(modelBuilder);
    }
}
