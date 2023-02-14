using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class PurchasedPartRepository : IPurchasedPartRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public PurchasedPartRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<PurchasedPart> byIdSpec)
        {
            var purchasedPart = await _context.PurchasedPart.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (purchasedPart == null)
                return;

            _ = _context.Remove(purchasedPart);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<PurchasedPart>> GetAll(ISpecification<PurchasedPart> filterBySpec, ISpecification<PurchasedPart> orderBySpec)
        {
            return await _context.PurchasedPart.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<List<PurchasedPart>> GetByEstimateId(ISpecification<PurchasedPart> byEstimateIdSpec, ISpecification<PurchasedPart> filterBySpec, ISpecification<PurchasedPart> orderBySpec)
        {
            return await _context.PurchasedPart.WithSpecification(byEstimateIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<PurchasedPart> GetById(ISpecification<PurchasedPart> byIdSpec)
        {
            var purchasedPart = await _context.PurchasedPart.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (purchasedPart == null)
                return new PurchasedPart();

            return purchasedPart;
        }

        public async Task<List<PurchasedPart>> GetByVehicleId(ISpecification<PurchasedPart> byVehicleIdSpec, ISpecification<PurchasedPart> filterBySpec, ISpecification<PurchasedPart> orderBySpec)
        {
            return await _context.PurchasedPart.WithSpecification(byVehicleIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<PurchasedPart> Insert(PurchasedPartViewModel purchasedPartViewModel)
        {
            if (purchasedPartViewModel == null)
                return new PurchasedPart();

            var purchasedPart = new PurchasedPart(purchasedPartViewModel);

            _ = _context.Add(purchasedPart);
            _ = await _context.SaveChangesAsync();

            return purchasedPart;
        }

        public async Task<PurchasedPart> Update(ISpecification<PurchasedPart> byIdSpec, PurchasedPartViewModel purchasedPartViewModel)
        {
            var purchasedPart = await _context.PurchasedPart.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (purchasedPart == null)
                return new PurchasedPart();

            if (purchasedPartViewModel == null)
                return new PurchasedPart();

            purchasedPart.Value = purchasedPartViewModel.Value;
            purchasedPart.UpsalePercent = purchasedPartViewModel.UpsalePercent;
            purchasedPart.VehicleId = purchasedPartViewModel.VehicleId;
            purchasedPart.EstimateId = purchasedPartViewModel.EstimateId;
            purchasedPart.Description = purchasedPartViewModel.Description;
            purchasedPart.Name = purchasedPartViewModel.Name;

            _ = _context.Update(purchasedPart);
            _ = await _context.SaveChangesAsync();

            return purchasedPart;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PurchasedPartRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
