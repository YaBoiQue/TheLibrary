using Ardalis.Specification;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class ServiceEstimatePriceRepository : IServiceEstimatePriceRepository
    {
        private bool disposedValue;

        public Task<ServiceEstimatePrice> Delete(ISpecification<ServiceEstimatePrice> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceEstimatePrice>> GetAll(ISpecification<ServiceEstimatePrice> filterBySpec, ISpecification<ServiceEstimatePrice> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceEstimatePrice> GetById(ISpecification<ServiceEstimatePrice> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceEstimatePrice> GetByServiceEstimateId(ISpecification<ServiceEstimatePrice> byServiceEstimateIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceEstimatePrice> Insert(ServiceEstimatePriceViewModel serviceEstimatePriceViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceEstimatePrice> Update(ISpecification<ServiceEstimatePrice> byIdSpec, ServiceEstimatePriceViewModel serviceEstimatePriceViewModel)
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
