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
        public DbSet<ShopSupply> ShopSupply { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estimate>()
                .HasKey(e => e.VehicleId);
            modelBuilder.Entity<Estimate>()
                .HasOne(e => e.Vehicle)
                .WithMany(v => v.Estimates)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<PurchasedPart>()
                .HasKey(p => p.VehicleId);
            modelBuilder.Entity<PurchasedPart>()
                .HasOne(p => p.Vehicle)
                .WithMany(v => v.ReplacedParts)
                .HasForeignKey(p => p.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}