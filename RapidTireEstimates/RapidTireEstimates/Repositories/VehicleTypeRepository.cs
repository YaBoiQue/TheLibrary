using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public VehicleTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<VehicleType> byIdSpec)
        {
            var type = await _context.VehicleType.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (type == null)
                return;

            _ = _context.Remove(type);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<VehicleType>> GetAll(ISpecification<VehicleType> filterBySpec, ISpecification<VehicleType> orderBySpec)
        {
            return await _context.VehicleType.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<VehicleType> GetById(ISpecification<VehicleType> byIdSpec)
        {
            var type = await _context.VehicleType.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            type ??= new VehicleType();

            return type;
        }

        public async Task<List<VehicleType>> GetByServiceId(ISpecification<VehicleType> byServiceIdSpec, ISpecification<VehicleType> filterBySpec, ISpecification<VehicleType> orderBySpec)
        {
            return await _context.VehicleType.WithSpecification(byServiceIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<VehicleType> GetByVehicleId(ISpecification<VehicleType> byVehicleIdSpec)
        {
            var type = await _context.VehicleType.WithSpecification(byVehicleIdSpec).SingleOrDefaultAsync();

            type ??= new VehicleType();

            return type;
        }

        public async Task<VehicleType> Insert(VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (vehicleTypeViewModel == null)
                return new VehicleType();

            _ = _context.Add(vehicleTypeViewModel.VehicleType);
            _ = await _context.SaveChangesAsync();

            return vehicleTypeViewModel.VehicleType;
        }

        public async Task<VehicleType> Update(ISpecification<VehicleType> byIdSpec, VehicleTypeViewModel vehicleTypeViewModel)
        {
            var type = await _context.VehicleType.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (type == null || vehicleTypeViewModel == null)
                return new VehicleType();

            if (type.Id != vehicleTypeViewModel.VehicleType.Id)
                return new VehicleType();

            type = vehicleTypeViewModel.VehicleType;

            _ = _context.Update(type);
            _ = await _context.SaveChangesAsync();

            return type;
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
        // ~VehicleTypeRepository()
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
