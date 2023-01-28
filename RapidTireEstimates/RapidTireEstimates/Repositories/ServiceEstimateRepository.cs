using Ardalis.Specification;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class ServiceEstimateRepository : IServiceEstimateRepository
    {
        private bool disposedValue;

        public Task<ServiceEstimate> Delete(ISpecification<ServiceEstimate> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceEstimate>> GetAll(ISpecification<ServiceEstimate> filterBySpec, ISpecification<ServiceEstimate> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceEstimate> GetByCommentId(ISpecification<ServiceEstimate> byCommentIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceEstimate>> GetByEstimateId(ISpecification<ServiceEstimate> byEstimateIdSpec, ISpecification<ServiceEstimate> filterBySpec, ISpecification<ServiceEstimate> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceEstimate> GetById(ISpecification<ServiceEstimate> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceEstimate> GetByPriceId(ISpecification<ServiceEstimate> byPriceIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceEstimate>> GetByServiceId(ISpecification<ServiceEstimate> byServiceIdSpec, ISpecification<ServiceEstimate> filterBySpec, ISpecification<ServiceEstimate> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceEstimate> Insert(ServiceEstimateViewModel serviceEstimateViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceEstimate> Update(ISpecification<ServiceEstimate> byIdSpec, ServiceEstimateViewModel serviceEstimateViewModel)
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
        // ~ServiceEstimateRepository()
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
