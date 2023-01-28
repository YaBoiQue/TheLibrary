using Ardalis.Specification;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private bool disposedValue;

        public Task Delete(ISpecification<Vehicle> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> GetAll(ISpecification<Vehicle> filterBySpec, ISpecification<Vehicle> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> GetByCustomerId(ISpecification<Vehicle> byCustomerIdSpec, ISpecification<Vehicle> filterBySpec, ISpecification<Vehicle> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetByEstimateId(ISpecification<Vehicle> byEstimateIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetById(ISpecification<Vehicle> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetByPurchasedPartId(ISpecification<Vehicle> byPurchasedPartIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> GetByVehicleTypeId(ISpecification<Vehicle> byVehicleIdSpec, ISpecification<Vehicle> filterBySpec, ISpecification<Vehicle> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> Insert(VehicleViewModel vehicleViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> Update(ISpecification<Vehicle> byIdSpec, VehicleViewModel vehicleViewModel)
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
