using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class ServiceEstimateRepository : IServiceEstimateRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public ServiceEstimateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<ServiceEstimate> byIdSpec)
        {
            var serviceEstimate = await _context.ServiceEstimate.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (serviceEstimate == null)
                return;

            _ = _context.Remove(serviceEstimate);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<ServiceEstimate>> GetAll(ISpecification<ServiceEstimate> filterBySpec, ISpecification<ServiceEstimate> orderBySpec)
        {
            return await _context.ServiceEstimate.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<ServiceEstimate> GetByCommentId(ISpecification<ServiceEstimate> byCommentIdSpec)
        {
            var serviceEstimate = await _context.ServiceEstimate.WithSpecification(byCommentIdSpec).SingleOrDefaultAsync();

            serviceEstimate ??= new ServiceEstimate();

            return serviceEstimate;
        }

        public async Task<List<ServiceEstimate>> GetByEstimateId(ISpecification<ServiceEstimate> byEstimateIdSpec, ISpecification<ServiceEstimate> filterBySpec, ISpecification<ServiceEstimate> orderBySpec)
        {
            return await _context.ServiceEstimate.WithSpecification(byEstimateIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<ServiceEstimate> GetById(ISpecification<ServiceEstimate> byIdSpec)
        {
            var serviceEstimate = await _context.ServiceEstimate.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            serviceEstimate ??= new ServiceEstimate();

            return serviceEstimate;
        }

        public async Task<ServiceEstimate> GetByPriceId(ISpecification<ServiceEstimate> byPriceIdSpec)
        {
            var serviceEstimate = await _context.ServiceEstimate.WithSpecification(byPriceIdSpec).SingleOrDefaultAsync();

            serviceEstimate ??= new ServiceEstimate();

            return serviceEstimate;
        }

        public async Task<List<ServiceEstimate>> GetByServiceId(ISpecification<ServiceEstimate> byServiceIdSpec, ISpecification<ServiceEstimate> filterBySpec, ISpecification<ServiceEstimate> orderBySpec)
        {
            return await _context.ServiceEstimate.WithSpecification(byServiceIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<ServiceEstimate> Insert(ServiceEstimateViewModel serviceEstimateViewModel)
        {
            if (serviceEstimateViewModel == null)
                return new ServiceEstimate();

            var serviceEstimate = new ServiceEstimate(serviceEstimateViewModel);

            _ = _context.Add(serviceEstimate);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<ServiceEstimate> Update(ISpecification<ServiceEstimate> byIdSpec, ServiceEstimateViewModel serviceEstimateViewModel)
        {
            var serviceEstimate = await _context.ServiceEstimate.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (serviceEstimateViewModel == null || serviceEstimate == null)
                return new ServiceEstimate();

            serviceEstimate.ServiceId = serviceEstimateViewModel.ServiceId;
            serviceEstimate.PriceId = serviceEstimateViewModel.PriceId;
            serviceEstimate.EstimateId = serviceEstimateViewModel.EstimateId;
            serviceEstimate.AdjustedHours = serviceEstimateViewModel.AdjustedHours;
            serviceEstimate.DateCreated = serviceEstimateViewModel.DateCreated;

            _ = _context.Update(serviceEstimate);
            _ = await _context.SaveChangesAsync();
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
        // ~ServiceEstimateRepository()
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
