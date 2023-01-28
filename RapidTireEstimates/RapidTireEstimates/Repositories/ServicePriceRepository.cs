using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class ServicePriceRepository : IServicePriceRepository
    {
        private bool disposedValue;
        private ApplicationDbContext _context;

        public ServicePriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<ServicePrice> byIdSpec)
        {
            ServicePrice? servicePrice = await _context.ServicePrice.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (servicePrice == null)
            {
                return;
            }

            _ = _context.ServicePrice.Remove(servicePrice);

            _ = await _context.SaveChangesAsync();

        }

        public async Task<ServicePrice> GetById(ISpecification<ServicePrice> byIdSpec)
        {
            if (byIdSpec == null)
            {
                return new ServicePrice();
            }
            var servicePrice = await _context.ServicePrice.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (servicePrice == null) 
            {
                return new ServicePrice();
            }
            return servicePrice;
        }

        public async Task<List<ServicePrice>> GetAll(ISpecification<ServicePrice> filterBySpec, ISpecification<ServicePrice> orderBySpec)
        {
            return await _context.ServicePrice.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<List<ServicePrice>> GetByServiceId(ISpecification<ServicePrice> byServiceIdSpec)
        {
            return await _context.ServicePrice.WithSpecification(byServiceIdSpec).ToListAsync();
        }

        public async Task<ServicePrice> Insert(ServicePriceViewModel servicePriceViewModel)
        {
            ServicePrice servicePrice = new ServicePrice();

            servicePrice.Description = servicePriceViewModel.Description;
            servicePrice.Level = servicePriceViewModel.Level;
            servicePrice.Value = servicePriceViewModel.Value;
            servicePrice.ServiceId = servicePriceViewModel.ServiceId;
            servicePrice.Service = servicePriceViewModel.Service;

            _ = _context.Add(servicePrice);
            _ = await _context.SaveChangesAsync();

            return servicePrice;
        }

        public async Task<ServicePrice> Update(ISpecification<ServicePrice> byIdSpec, ServicePriceViewModel servicePriceViewModel)
        {
            ServicePrice? servicePrice;

            try
            {
                servicePrice = await _context.ServicePrice.WithSpecification(byIdSpec).SingleOrDefaultAsync();

                if (servicePrice == null) 
                    return new ServicePrice();

                servicePrice.Value = servicePriceViewModel.Value;
                servicePrice.Level = servicePriceViewModel.Level;
                servicePrice.ServiceId = servicePriceViewModel.ServiceId;
                if (servicePriceViewModel.Description != null)
                {
                    servicePrice.Description = servicePriceViewModel.Description.Trim();
                }

                _ = _context.Update(servicePrice);
                _ = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicePriceExists(servicePriceViewModel.Id))
                {
                    return new ServicePrice();
                }
                else
                {
                    throw;
                }
            }

            return servicePrice;
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
        // ~ServicePriceRepository()
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

        public Task<List<ServicePrice>> GetByServiceId(ISpecification<ServicePrice> byServiceIdSpec, ISpecification<ServicePrice> filterBySpec, ISpecification<ServicePrice> orderBySpec)
        {
            throw new NotImplementedException();
        }


        private bool ServicePriceExists(int id)
        {
            return _context.ServicePrice.Any(e => e.Id == id);
        }
    }
}
