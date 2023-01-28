using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IEstimateRepository : IDisposable
    {
        public Task<List<Estimate>> GetAll(
            ISpecification<Estimate> filterBySpec,
            ISpecification<Estimate> orderBySpec
            );
        public Task<List<Estimate>> GetByCustomerId(
            ISpecification<Estimate> byCustomerIdSpec,
            ISpecification<Estimate> filterBySpec,
            ISpecification<Estimate> orderBySpec
            );
        public Task<List<Estimate>> GetByVehicleId(
            ISpecification<Estimate> byVehicleIdSpec,
            ISpecification<Estimate> filterBySpec,
            ISpecification<Estimate> orderBySpec
            );
        public Task<List<Estimate>> GetByShopSupplyId(
            ISpecification<Estimate> byShopSupplyIdSpec,
            ISpecification<Estimate> filterBySpec,
            ISpecification<Estimate> orderBySpec
            );
        public Task<Estimate> GetById(
            ISpecification<Estimate> byIdSpec
            );
        public Task<Estimate> GetByPurchasedPartId(
            ISpecification<Estimate> byPurchasedPartIdSpec
            );
        public Task<Estimate> GetByServiceEstimateId(
            ISpecification<Estimate> byServiceEstimateIdSpec
            );
        public Task<Estimate> Insert(
            EstimateViewModel estimateViewModel
            );
        public Task<Estimate> Update(
            EstimateViewModel estimateViewModel
            );
        public Task Delete(
            ISpecification<Estimate> byIdSpec
            );
    }
}
