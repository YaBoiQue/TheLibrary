using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private bool disposedValue;
        private ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteService(ISpecification<Service> byIdSpec)
        {
            Service? service = await _context.Service.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (service != null)
            {
                List<Service> services = await _context.Service.Where(s => s.Name == service.Name).ToListAsync();

                foreach (Service? item in services)
                {
                    if (item.ServiceNumber > service.ServiceNumber)
                    {
                        item.ServiceNumber--;
                    }

                    try
                    {
                        _ = _context.Update(item);
                        _ = await _context.SaveChangesAsync();

                    }
                    catch
                    {
                        return;
                    }

                }

                var servicePrices = await _context.ServicePrice.Where(p => p.ServiceId == service.Id).ToListAsync();

                /*
                foreach(var item in servicePrices)
                {
                    _ = _context.ServicePrice.Remove(item);
                }
                */

                _ = _context.Service.Remove(service);
            }

            _ = await _context.SaveChangesAsync();
        }

        public async Task<Service> GetServiceById(ISpecification<Service> byIdSpec)
        {
            if (byIdSpec == null)
            {
                return new Service();
            }
            var service = await _context.Service.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (service == null)
            {
                return new Service();
            }
            return service;
        }

        public Task<Service> GetServiceByServiceEstimateId(ISpecification<Service> byIdServiceEstimateSpec)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Service>> GetServices(ISpecification<Service> filterBySpec, ISpecification<Service> orderBySpec)
        {
            var services = await _context.Service.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();

            foreach (var item in services)
            {
                item.VehicleTypes = await _context.ServiceVehicleType.Where(v => v.ServicesId == item.Id).ToListAsync();
                item.Prices = await _context.ServicePrice.Where(p => p.ServiceId == item.Id).ToListAsync();
            }

            return services;
        }

        public async Task<List<Service>> GetServicesByName(ISpecification<Service> byNameSpec, ISpecification<Service> filterBySpec, ISpecification<Service> orderBySpec)
        {
            var services = await _context.Service.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();

            if (services == null)
                return new List<Service>();

            return services;
        }

        public async Task<List<Service>> GetServicesByVehicleTypeId(ISpecification<Service> byServiceVehicleIdSpec, ISpecification<Service> filterBySpec, ISpecification<Service> orderBySpec )
        {
            return await _context.Service.WithSpecification(byServiceVehicleIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<Service> InsertService(ServiceViewModel serviceViewModel)
        {
            if (serviceViewModel == null)
                return new Service();

            Service? service = new() { Id = serviceViewModel.Id, Name = serviceViewModel.Name, Description = serviceViewModel.Description, Hours = serviceViewModel.Hours, Rate = serviceViewModel.Rate };

            List<Service> services = await _context.Service.Where(s => s.Name == serviceViewModel.Name).ToListAsync();

            service.ServiceNumber = services.Count;
            

            _ = _context.Add(service);
            _ = await _context.SaveChangesAsync();

            if (serviceViewModel.VehicleTypeSelectList == null)
            {
                return service;
            }

            service = await _context.Service.Where(s => s.Name == serviceViewModel.Name && s.ServiceNumber == service.ServiceNumber).SingleOrDefaultAsync();

            if (service == null)
                return new Service();

            foreach (SelectListItem item in serviceViewModel.VehicleTypeSelectList)
            {
                if (item.Selected == true)
                {
                    VehicleType? vehicleType = await _context.VehicleType.Where(v => v.Id.ToString() == item.Value).SingleOrDefaultAsync();
                    ServiceVehicleType serviceVehicleType = new(service.Id, vehicleType.Id) { Name = vehicleType.Name };
                    _ = _context.Add(serviceVehicleType);
                }
            }

            _ = await _context.SaveChangesAsync();

            return service;
        }

        public async Task<Service> UpdateService(ISpecification<Service> byIdSpec, ServiceViewModel serviceViewModel)
        {
            Service? service;

            try
            {
                service = await _context.Service.WithSpecification(byIdSpec).SingleOrDefaultAsync();

                if (service == null)
                {
                    return new Service();
                }

                service.Name = serviceViewModel.Name;
                service.Description = serviceViewModel.Description;
                service.Rate = serviceViewModel.Rate;
                service.Hours = serviceViewModel.Hours;

                _ = _context.Update(service);
                _ = await _context.SaveChangesAsync();
            }
            catch
            {
                if (!ServiceExists(serviceViewModel.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return service;
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

        private bool ServiceExists(int id)
        {
            return _context.ServicePrice.Any(e => e.Id == id);
        }

        public async Task<List<VehicleType>> GetVehicleTypes()
        {
            return await _context.VehicleType.ToListAsync();
        }
    }
}
