using Ardalis.Specification;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private bool disposedValue;

        public Task Delete(ISpecification<VehicleType> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleType>> GetAll(ISpecification<VehicleType> filterBySpec, ISpecification<VehicleType> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleType> GetById(ISpecification<VehicleType> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleType>> GetByServiceId(ISpecification<VehicleType> byServiceIdSpec, ISpecification<VehicleType> filterBySpec, ISpecification<VehicleType> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleType> GetByVehicleId(ISpecification<VehicleType> byVehicleIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleType> Insert(VehicleTypeViewModel vehicleTypeViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleType> Update(ISpecification<VehicleType> byIdSpec, VehicleTypeViewModel vehicleTypeViewModel)
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
