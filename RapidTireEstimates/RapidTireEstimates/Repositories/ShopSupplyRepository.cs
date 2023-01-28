using Ardalis.Specification;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class ShopSupplyRepository : IShopSupplyRepository
    {
        private bool disposedValue;

        public Task<ShopSupply> Delete(ISpecification<ShopSupply> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShopSupply>> GetAll(ISpecification<ShopSupply> filterBySpec, ISpecification<ShopSupply> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShopSupply>> GetByEstimateId(ISpecification<ShopSupply> byEstimateIdSpec, ISpecification<ShopSupply> filterBySpec, ISpecification<ShopSupply> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<ShopSupply> GetById(ISpecification<ShopSupply> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<ShopSupply> Insert(ShopSupplyViewModel shopSupplyViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ShopSupply> Update(ISpecification<ShopSupply> byIdSpec, ShopSupplyViewModel shopSupplyViewModel)
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
        // ~ShopSupplyRepository()
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
