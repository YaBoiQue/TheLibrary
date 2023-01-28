using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Models;
using RapidTireEstimates.Models.Linkers;

namespace RapidTireEstimates.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customer => Set<Customer>();
        public DbSet<CustomerComment> CustomerComment => Set<CustomerComment>();
        public DbSet<Estimate> Estimate => Set<Estimate>();
        public DbSet<EstimateShopSupply> EstimateShopSupply => Set<EstimateShopSupply>();
        public DbSet<EstimateComment> EstimateComment => Set<EstimateComment>();
        public DbSet<PurchasedPart> PurchasedPart => Set<PurchasedPart>();
        public DbSet<Service> Service => Set<Service>();
        public DbSet<ServiceEstimate> ServiceEstimate => Set<ServiceEstimate>();
        public DbSet<ServiceEstimateComment> ServiceEstimateComment => Set<ServiceEstimateComment>();
        public DbSet<ServiceEstimatePrice> ServiceEstimatePrice => Set<ServiceEstimatePrice>();
        public DbSet<ServicePrice> ServicePrice => Set<ServicePrice>();
        public DbSet<ServiceVehicleType> ServiceVehicleType => Set<ServiceVehicleType>();
        public DbSet<ShopSupply> ShopSupply => Set<ShopSupply>();
        public DbSet<Vehicle> Vehicle => Set<Vehicle>(); 
        public DbSet<VehicleType> VehicleType => Set<VehicleType>();

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