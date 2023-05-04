using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public VehicleRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<Vehicle> byIdSpec)
        {
            var vehicle = await _context.Vehicle.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (vehicle == null)
                return;

            _ = _context.Remove(vehicle);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> GetAll(ISpecification<Vehicle> filterBySpec, ISpecification<Vehicle> orderBySpec)
        {
            return await _context.Vehicle.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<List<Vehicle>> GetByCustomerId(ISpecification<Vehicle> byCustomerIdSpec, ISpecification<Vehicle> filterBySpec, ISpecification<Vehicle> orderBySpec)
        {
            return await _context.Vehicle.WithSpecification(byCustomerIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<Vehicle> GetByEstimateId(ISpecification<Vehicle> byEstimateIdSpec)
        {
            var vehicle = await _context.Vehicle.WithSpecification(byEstimateIdSpec).SingleOrDefaultAsync();

            vehicle ??= new Vehicle();

            return vehicle;
        }

        public async Task<Vehicle> GetById(ISpecification<Vehicle> byIdSpec)
        {
            var vehicle = await _context.Vehicle.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            vehicle ??= new Vehicle();

            return vehicle;
        }

        public Task<Vehicle> GetByPurchasedPartId(ISpecification<Vehicle> byPurchasedPartIdSpec)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Vehicle>> GetByVehicleTypeId(ISpecification<Vehicle> byVehicleIdSpec, ISpecification<Vehicle> filterBySpec, ISpecification<Vehicle> orderBySpec)
        {
            return await _context.Vehicle.WithSpecification(byVehicleIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<Vehicle> Insert(VehicleViewModel vehicleViewModel)
        {
            if (vehicleViewModel == null)
                return new Vehicle();

            _ = _context.Add(vehicleViewModel.Vehicle);
            _ = await _context.SaveChangesAsync();

            return vehicleViewModel.Vehicle;
        }

        public async Task<Vehicle> Update(ISpecification<Vehicle> byIdSpec, VehicleViewModel vehicleViewModel)
        {
            var vehicle = await _context.Vehicle.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (vehicle == null || vehicleViewModel == null)
                return new Vehicle();

            if (vehicle.Id != vehicleViewModel.Vehicle.Id)
                return new Vehicle();

            vehicle = vehicleViewModel.Vehicle;

            _ = _context.Update(vehicle);
            _ = await _context.SaveChangesAsync();

            return vehicle;
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
        // ~VehicleRepository()
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
