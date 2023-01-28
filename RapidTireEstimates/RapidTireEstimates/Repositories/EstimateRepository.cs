using Ardalis.Specification;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class EstimateRepository : IEstimateRepository
    {
        private bool disposedValue;

        public Task Delete(ISpecification<Estimate> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<Estimate>> GetAll(ISpecification<Estimate> filterBySpec, ISpecification<Estimate> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<Estimate>> GetByCustomerId(ISpecification<Estimate> byCustomerIdSpec, ISpecification<Estimate> filterBySpec, ISpecification<Estimate> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<Estimate> GetById(ISpecification<Estimate> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<Estimate> GetByPurchasedPartId(ISpecification<Estimate> byPurchasedPartIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<Estimate> GetByServiceEstimateId(ISpecification<Estimate> byServiceEstimateIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<Estimate>> GetByShopSupplyId(ISpecification<Estimate> byShopSupplyIdSpec, ISpecification<Estimate> filterBySpec, ISpecification<Estimate> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<Estimate>> GetByVehicleId(ISpecification<Estimate> byVehicleIdSpec, ISpecification<Estimate> filterBySpec, ISpecification<Estimate> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<Estimate> Insert(EstimateViewModel estimateViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Estimate> Update(EstimateViewModel estimateViewModel)
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
        // ~EstimateRepository()
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
