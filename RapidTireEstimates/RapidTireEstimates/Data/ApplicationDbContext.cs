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
            //Set up keys
            //CustomerComments
            _ = modelBuilder.Entity<CustomerComment>()
                .HasKey(c => c.CustomerId);
            //Estimate
            _ = modelBuilder.Entity<Estimate>()
                .HasKey(e => e.VehicleId);
            _ = modelBuilder.Entity<Estimate>()
                .HasKey(e => e.CustomerId);
            //EstimateComment
            _ = modelBuilder.Entity<EstimateComment>()
                .HasKey(e => e.EstimateId);
            //PurchasedPart
            _ = modelBuilder.Entity<PurchasedPart>()
                .HasKey(p => p.VehicleId);
            _ = modelBuilder.Entity<PurchasedPart>()
                .HasKey(p => p.EstimateId);
            //ServiceEstimate
            _ = modelBuilder.Entity<ServiceEstimate>()
                .HasKey(s => s.ServiceId);
            _ = modelBuilder.Entity<ServiceEstimate>()
                .HasKey(s => s.EstimateId);
            _ = modelBuilder.Entity<ServiceEstimate>()
                .HasKey(s => s.PriceId);
            //ServiceEstimateComment
            _ = modelBuilder.Entity<ServiceEstimateComment>()
                .HasKey(s => s.ServiceEstimateId);
            //ServiceEstimatePrice
            _ = modelBuilder.Entity<ServiceEstimatePrice>()
                .HasKey(s => s.ServiceEstimateId);
            //ServicePrice
            _ = modelBuilder.Entity<ServicePrice>()
                .HasKey(s => s.ServiceId);
            //Vehicle
            _ = modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.VehicleTypeId);
            _ = modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.CustomerId);
            //EstimateShopSupply
            _ = modelBuilder.Entity<EstimateShopSupply>()
                .HasKey(e => e.ShopSupplyId);
            _ = modelBuilder.Entity<EstimateShopSupply>()
                .HasKey(e => e.EstimateId);
            //ServiceVehicleType
            _ = modelBuilder.Entity<ServiceVehicleType>()
                .HasKey(s => s.ServicesId);
            _ = modelBuilder.Entity<ServiceVehicleType>()
                .HasKey(s => s.VehicleTypesId);


            /*----Cascading----*/
            //Customer
            _ = modelBuilder.Entity<Customer>()
                .HasMany(c => c.Estimates)
                .WithOne(e => e.Customer);
            _ = modelBuilder.Entity<Customer>()
                .HasMany(c => c.Vehicles)
                .WithOne(v => v.Customer);
            _ = modelBuilder.Entity<Customer>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.Customer);
            //CustomerComment
            _ = modelBuilder.Entity<CustomerComment>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            //Estimate
            _ = modelBuilder.Entity<Estimate>()
                .HasMany(e => e.Services)
                .WithOne(s => s.Estimate);
            _ = modelBuilder.Entity<Estimate>()
                .HasMany(e => e.PurchasedParts)
                .WithOne(p => p.Estimate);
            _ = modelBuilder.Entity<Estimate>()
                .HasMany(e => e.ShopSupplies)
                .WithOne(s => s.Estimate);
            _ = modelBuilder.Entity<Estimate>()
                .HasMany(e => e.Comments)
                .WithOne(c => c.Estimate);
            _ = modelBuilder.Entity<Estimate>()
                .HasOne(e => e.Customer)
                .WithMany(c => c.Estimates)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            _ = modelBuilder.Entity<Estimate>()
                .HasOne(e => e.Vehicle)
                .WithMany(v => v.Estimates)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
            //EstimateComment
            _ = modelBuilder.Entity<EstimateComment>()
                .HasOne(c => c.Estimate)
                .WithMany(e => e.Comments)
                .HasForeignKey(c => c.EstimateId)
                .OnDelete(DeleteBehavior.Cascade);
            //PurchasedPart
            _ = modelBuilder.Entity<PurchasedPart>()
                .HasOne(p => p.Vehicle)
                .WithMany(v => v.ReplacedParts)
                .HasForeignKey(p => p.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
            _ = modelBuilder.Entity<PurchasedPart>()
                .HasOne(p => p.Estimate)
                .WithMany(e => e.PurchasedParts)
                .HasForeignKey(p => p.EstimateId)
                .OnDelete(DeleteBehavior.Cascade);
            //Service
            _ = modelBuilder.Entity<Service>()
                .HasMany(s => s.ServiceEstimates)
                .WithOne(e => e.Service);
            _ = modelBuilder.Entity<Service>()
                .HasMany(s => s.Prices)
                .WithOne(p => p.Service);
            _ = modelBuilder.Entity<Service>()
                .HasMany(s => s.VehicleTypes)
                .WithOne(v => v.Service);
            //ServiceEstimate
            _ = modelBuilder.Entity<ServiceEstimate>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.ServiceEstimate);
            _ = modelBuilder.Entity<ServiceEstimate>()
                .HasOne(s => s.Estimate)
                .WithMany(e => e.Services)
                .HasForeignKey(s => s.EstimateId)
                .OnDelete(DeleteBehavior.Cascade);
            _ = modelBuilder.Entity<ServiceEstimate>()
                .HasOne(e => e.Service)
                .WithMany(s => s.ServiceEstimates)
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
            //ServiceEstimateComment
            _ = modelBuilder.Entity<ServiceEstimateComment>()
                .HasOne(c => c.ServiceEstimate)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.ServiceEstimateId)
                .OnDelete(DeleteBehavior.Cascade);
            //ServiceEstimatePrice
            _ = modelBuilder.Entity<ServiceEstimatePrice>()
                .HasOne(s => s.ServiceEstimate)
                .WithOne(e => e.Price)
                .OnDelete(DeleteBehavior.Cascade);
            //ServicePrice
            _ = modelBuilder.Entity<ServicePrice>()
                .HasOne(p => p.Service)
                .WithMany(s => s.Prices)
                .HasForeignKey(p => p.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
            //ShopSupply
            _ = modelBuilder.Entity<ShopSupply>()
                .HasMany(s => s.Estimates)
                .WithOne(e => e.ShopSupply);
            //Vehicle
            _ = modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.Estimates)
                .WithOne(e => e.Vehicle);
            _ = modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.ReplacedParts)
                .WithOne(r => r.Vehicle);
            _ = modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Customer)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            _ = modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            //VehicleType
            _ = modelBuilder.Entity<VehicleType>()
                .HasMany(t => t.Vehicles)
                .WithOne(v => v.VehicleType);
            _ = modelBuilder.Entity<VehicleType>()
                .HasMany(t => t.Services)
                .WithOne(s => s.VehicleType);
            //EstimateShopSupply
            _ = modelBuilder.Entity<EstimateShopSupply>()
                .HasOne(e => e.ShopSupply)
                .WithMany(s => s.Estimates)
                .HasForeignKey(e => e.ShopSupplyId)
                .OnDelete(DeleteBehavior.Cascade);
            _ = modelBuilder.Entity<EstimateShopSupply>()
                .HasOne(s => s.Estimate)
                .WithMany(e => e.ShopSupplies)
                .HasForeignKey(s => s.EstimateId)
                .OnDelete(DeleteBehavior.Cascade);
            //ServiceVehicleType
            _ = modelBuilder.Entity<ServiceVehicleType>()
                .HasOne(v => v.Service)
                .WithMany(s => s.VehicleTypes)
                .HasForeignKey(v => v.ServicesId)
                .OnDelete(DeleteBehavior.Cascade);
            _ = modelBuilder.Entity<ServiceVehicleType>()
                .HasOne(s => s.VehicleType)
                .WithMany(v => v.Services)
                .HasForeignKey(s => s.VehicleTypesId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}