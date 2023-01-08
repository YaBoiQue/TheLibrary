using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerComment> CustomerComment { get; set; }
        public DbSet<Estimate> Estimate { get; set; }
        public DbSet<EstimateComment> EstimateComment { get; set; }
        public DbSet<PurchasedPart> PurchasedPart { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceEstimate> ServiceEstimate { get; set; }
        public DbSet<ServiceEstimateComment> ServiceEstimateComment { get; set; }
        public DbSet<ServiceEstimatePrice> ServiceEstimatePrice { get; set; }
        public DbSet<ServicePrice> ServicePrice { get; set; }
        public DbSet<ServiceVehicleType> ServiceVehicleType { get; set; }
        public DbSet<ShopSupply> ShopSupply { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Estimate>()
                .HasKey(e => e.VehicleId);
            _ = modelBuilder.Entity<Estimate>()
                .HasOne(e => e.Vehicle)
                .WithMany(v => v.Estimates)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            _ = modelBuilder.Entity<PurchasedPart>()
                .HasKey(p => p.VehicleId);
            _ = modelBuilder.Entity<PurchasedPart>()
                .HasOne(p => p.Vehicle)
                .WithMany(v => v.ReplacedParts)
                .HasForeignKey(p => p.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<Service>()
                .HasMany(s => s.VehicleTypes)
                .WithOne(v => v.Service);

            _ = modelBuilder.Entity<VehicleType>()
                .HasMany(v => v.Services)
                .WithOne(s => s.VehicleType);

            _ = modelBuilder.Entity<Service>()
                .HasMany(s => s.Prices)
                .WithOne(p => p.Service);
            _ = modelBuilder.Entity<ServicePrice>()
                .HasOne(p => p.Service)
                .WithMany(s => s.Prices)
                .HasForeignKey(p => p.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}