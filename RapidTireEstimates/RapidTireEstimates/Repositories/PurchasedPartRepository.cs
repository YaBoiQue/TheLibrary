using Ardalis.Specification;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class PurchasedPartRepository : IPurchasedPartRepository
    {
        private bool disposedValue;

        public Task<PurchasedPart> Delete(ISpecification<PurchasedPart> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchasedPart>> GetAll(ISpecification<PurchasedPart> filterBySpec, ISpecification<PurchasedPart> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchasedPart>> GetByEstimateId(ISpecification<PurchasedPart> byEstimateIdSpec, ISpecification<PurchasedPart> filterBySpec, ISpecification<PurchasedPart> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<PurchasedPart> GetById(ISpecification<PurchasedPart> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchasedPart>> GetByVehicleId(ISpecification<PurchasedPart> byVehicleIdSpec, ISpecification<PurchasedPart> filterBySpec, ISpecification<PurchasedPart> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<PurchasedPart> Insert(PurchasedPartViewModel purchasedPartViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<PurchasedPart> Update(ISpecification<PurchasedPart> byIdSpec, PurchasedPartViewModel purchasedPartViewModel)
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
        // ~PurchasedPartRepository()
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
