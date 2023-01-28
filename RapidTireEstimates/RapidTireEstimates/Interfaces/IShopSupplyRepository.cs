using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IShopSupplyRepository : IDisposable
    {
        public Task<List<ShopSupply>> GetAll(
            ISpecification<ShopSupply> filterBySpec,
            ISpecification<ShopSupply> orderBySpec
            );
        public Task<List<ShopSupply>> GetByEstimateId(
            ISpecification<ShopSupply> byEstimateIdSpec,
            ISpecification<ShopSupply> filterBySpec,
            ISpecification<ShopSupply> orderBySpec
            );
        public Task<ShopSupply> GetById(
            ISpecification<ShopSupply> byIdSpec
            );
        public Task<ShopSupply> Insert(
            ShopSupplyViewModel shopSupplyViewModel
            );
        public Task<ShopSupply> Update(
            ISpecification<ShopSupply> byIdSpec,
            ShopSupplyViewModel shopSupplyViewModel
            );
        public Task<ShopSupply> Delete(
            ISpecification<ShopSupply> byIdSpec
            );
    }
}
