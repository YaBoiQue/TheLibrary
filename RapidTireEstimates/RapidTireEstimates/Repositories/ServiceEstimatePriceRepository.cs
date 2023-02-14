using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class ServiceEstimatePriceRepository : IServiceEstimatePriceRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public ServiceEstimatePriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<ServiceEstimatePrice> byIdSpec)
        {
            var serviceEstimatePrice = await _context.ServiceEstimatePrice.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (serviceEstimatePrice == null)
                return;

            _ = _context.Remove(serviceEstimatePrice);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<ServiceEstimatePrice>> GetAll(ISpecification<ServiceEstimatePrice> filterBySpec, ISpecification<ServiceEstimatePrice> orderBySpec)
        {
            return await _context.ServiceEstimatePrice.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<ServiceEstimatePrice> GetById(ISpecification<ServiceEstimatePrice> byIdSpec)
        {
            var price = await _context.ServiceEstimatePrice.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (price == null)
                return new ServiceEstimatePrice();

            return price;
        }

        public async Task<ServiceEstimatePrice> GetByServiceEstimateId(ISpecification<ServiceEstimatePrice> byServiceEstimateIdSpec)
        {
            var price = await _context.ServiceEstimatePrice.WithSpecification(byServiceEstimateIdSpec).SingleOrDefaultAsync();

            if (price == null)
                return new ServiceEstimatePrice();

            return price;
        }

        public async Task<ServiceEstimatePrice> Insert(ServiceEstimatePriceViewModel serviceEstimatePriceViewModel)
        {
            if (serviceEstimatePriceViewModel == null)
                return new ServiceEstimatePrice();

            var price = new ServiceEstimatePrice(serviceEstimatePriceViewModel);

            _ = _context.Add(price);
            _ = await _context.SaveChangesAsync();

            return price;
        }

        public async Task<ServiceEstimatePrice> Update(ISpecification<ServiceEstimatePrice> byIdSpec, ServiceEstimatePriceViewModel serviceEstimatePriceViewModel)
        {
            var price = await _context.ServiceEstimatePrice.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (serviceEstimatePriceViewModel == null || price == null)
                return new ServiceEstimatePrice();

            price.Value = serviceEstimatePriceViewModel.Value;
            price.Comment = serviceEstimatePriceViewModel.Comment;

            _ = _context.Update(price);
            _ = await _context.SaveChangesAsync();

            return price;
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
        // ~ServiceEstimatePriceRepository()
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
