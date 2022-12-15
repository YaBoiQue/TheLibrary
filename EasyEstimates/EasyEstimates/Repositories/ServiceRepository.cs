using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using EasyEstimates.Data;
using EasyEstimates.IRepository;
using EasyEstimates.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEstimates.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private bool disposedValue;
        private EasyEstimatesContext _context;

        public ServiceRepository(EasyEstimatesContext context)
        {
            _context = context;
        }

        public async Task<Service> GetService(Specification<Service> byIdSpec)
        {
            return await _context.Services.WithSpecification(byIdSpec).SingleOrDefaultAsync();
        }

        async Task<ICollection<Service>> IServiceRepository.GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        async Task<ICollection<Service>> IServiceRepository.GetServicesBySpecId(Specification<Service> bySpecIdSpec)
        {
            return await _context.Services.WithSpecification(bySpecIdSpec).ToListAsync();
        }

        async Task<Service> IServiceRepository.AddService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return service;
        }

        async Task IServiceRepository.RemoveService(Service service)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
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
        // ~ServiceRepository()
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
