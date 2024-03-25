using System;
using System.Collections.Generic;
using HarnessHelper.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace HarnessHelper.Data;

public partial class HarnessDbContext : DbContext
{
    public HarnessDbContext()
    {
    }

    public HarnessDbContext(DbContextOptions<HarnessDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Devicetotal> Devicetotals { get; set; }

    public virtual DbSet<Pin> Pins { get; set; }

    public virtual DbSet<Plug> Plugs { get; set; }

    public virtual DbSet<Plugtotal> Plugtotals { get; set; }

    public virtual DbSet<Wire> Wires { get; set; }

    public virtual DbSet<Wiretotal> Wiretotals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql(/*"server=localhost;port=3306;database=harnessdb;user=dev;password=KnightDev7601*"*/
            "server=host.docker.internal;port=3306;database=identitydb;user=dev;password=KnightDev7601*", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorCode).HasName("PRIMARY");

            entity.ToTable("colors");

            entity.Property(e => e.ColorCode)
                .HasMaxLength(45)
                .HasComment("Solid colors consist of\nBlack = BK\nBrown = BN\nRed = RD\nOrange = OG\nYellow = YE\nGreen = GN\nBlue = BU\nViolent = VT\nGrey = GY\nWhite = WH\nPink = PK\nGold = GD\nTurquoise = TQ\nSilver = SR\nGreen - Yellow = GNYE\n\nFor striped wires use Solid/Stripe")
                .HasColumnName("colorCode");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.SolidValue)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("solidValue");
            entity.Property(e => e.StripeValue)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("stripeValue");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.DeviceId).HasName("PRIMARY");

            entity.ToTable("devices");

            entity.HasIndex(e => e.DeviceId, "deviceId_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserId, "device_user_idx");

            entity.Property(e => e.DeviceId)
                .ValueGeneratedNever()
                .HasColumnName("deviceId");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.NumPlugSpots).HasColumnName("numPlugSpots");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .HasColumnName("userId");
        });

        modelBuilder.Entity<Devicetotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("devicetotals");

            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DeviceId).HasColumnName("deviceId");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.NumDevices)
                .HasPrecision(32)
                .HasColumnName("numDevices");
            entity.Property(e => e.NumPlugSpots).HasColumnName("numPlugSpots");
            entity.Property(e => e.NumPlugs)
                .HasPrecision(32)
                .HasColumnName("numPlugs");
            entity.Property(e => e.NumWires)
                .HasPrecision(32)
                .HasColumnName("numWires");
        });

        modelBuilder.Entity<Pin>(entity =>
        {
            entity.HasKey(e => e.PinId).HasName("PRIMARY");

            entity.ToTable("pins");

            entity.HasIndex(e => e.PlugId, "pin_plug_idx");

            entity.HasIndex(e => e.WireId, "pin_wire_idx");

            entity.Property(e => e.PinId).HasColumnName("pinId");
            entity.Property(e => e.PlugId).HasColumnName("plugId");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .HasColumnName("userId");
            entity.Property(e => e.WireId).HasColumnName("wireId");

            entity.HasOne(d => d.Plug).WithMany(p => p.Pins)
                .HasForeignKey(d => d.PlugId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pin_plug");

            entity.HasOne(d => d.Wire).WithMany(p => p.Pins)
                .HasForeignKey(d => d.WireId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pin_wire");
        });

        modelBuilder.Entity<Plug>(entity =>
        {
            entity.HasKey(e => e.PlugId).HasName("PRIMARY");

            entity.ToTable("plugs");

            entity.HasIndex(e => e.PlugId, "plugId_UNIQUE").IsUnique();

            entity.HasIndex(e => e.DeviceId, "plug_device_idx");

            entity.HasIndex(e => e.UserId, "plug_user_idx");

            entity.Property(e => e.PlugId).HasColumnName("plugId");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DeviceId).HasColumnName("deviceId");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.NumPinHoles).HasColumnName("numPinHoles");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .HasColumnName("userId");

            entity.HasOne(d => d.Device).WithMany(p => p.Plugs)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("plug_device");
        });

        modelBuilder.Entity<Plugtotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("plugtotals");

            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DeviceId).HasColumnName("deviceId");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.NumPinHoles).HasColumnName("numPinHoles");
            entity.Property(e => e.NumWires)
                .HasPrecision(32)
                .HasColumnName("numWires");
            entity.Property(e => e.PlugId).HasColumnName("plugId");
        });

        modelBuilder.Entity<Wire>(entity =>
        {
            entity.HasKey(e => e.WireId).HasName("PRIMARY");

            entity.ToTable("wires");

            entity.HasIndex(e => e.WireId, "wireId_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserId, "wire_user_idx");

            entity.Property(e => e.WireId).HasColumnName("wireId");
            entity.Property(e => e.ColorCode)
                .HasMaxLength(45)
                .HasColumnName("colorCode");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Gauge)
                .HasMaxLength(3)
                .HasColumnName("gauge");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .HasColumnName("userId");
        });

        modelBuilder.Entity<Wiretotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("wiretotals");

            entity.Property(e => e.ColorCode)
                .HasMaxLength(45)
                .HasColumnName("colorCode");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Gauge)
                .HasMaxLength(3)
                .HasColumnName("gauge");
            entity.Property(e => e.NumPlugs)
                .HasPrecision(32)
                .HasColumnName("numPlugs");
            entity.Property(e => e.WireId).HasColumnName("wireId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
