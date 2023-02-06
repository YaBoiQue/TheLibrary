using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class EstimateRepository : IEstimateRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public EstimateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<Estimate> byIdSpec)
        {
            var estimate = await _context.Estimate.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (estimate == null)
                return;

            _ = _context.Remove(estimate);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<Estimate>> GetAll(ISpecification<Estimate> filterBySpec, ISpecification<Estimate> orderBySpec)
        {
            return await _context.Estimate.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<List<Estimate>> GetByCustomerId(ISpecification<Estimate> byCustomerIdSpec, ISpecification<Estimate> filterBySpec, ISpecification<Estimate> orderBySpec)
        {
            return await _context.Estimate.WithSpecification(byCustomerIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<Estimate> GetById(ISpecification<Estimate> byIdSpec)
        {
            var estimate = await _context.Estimate.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            estimate ??= new Estimate();

            return estimate;
        }

        public async Task<Estimate> GetByPurchasedPartId(ISpecification<Estimate> byPurchasedPartIdSpec)
        {
            var estimate = await _context.Estimate.WithSpecification(byPurchasedPartIdSpec).SingleOrDefaultAsync();

            estimate ??= new Estimate();

            return estimate;
        }

        public async Task<Estimate> GetByServiceEstimateId(ISpecification<Estimate> byServiceEstimateIdSpec)
        {
            var estimate = await _context.Estimate.WithSpecification(byServiceEstimateIdSpec).SingleOrDefaultAsync();

            estimate ??= new Estimate();

            return estimate;
        }

        public async Task<List<Estimate>> GetByShopSupplyId(ISpecification<Estimate> byShopSupplyIdSpec, ISpecification<Estimate> filterBySpec, ISpecification<Estimate> orderBySpec)
        {
            return await _context.Estimate.WithSpecification(byShopSupplyIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<List<Estimate>> GetByVehicleId(ISpecification<Estimate> byVehicleIdSpec, ISpecification<Estimate> filterBySpec, ISpecification<Estimate> orderBySpec)
        {
            return await _context.Estimate.WithSpecification(byVehicleIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<Estimate> Insert(EstimateViewModel estimateViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Estimate> Update(EstimateViewModel estimateViewModel)
        {
            throw new NotImplementedException();
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
        // ~EstimateRepository()
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
