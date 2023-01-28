using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IServiceEstimatePriceRepository : IDisposable
    {
        public Task<List<ServiceEstimatePrice>> GetAll(
            ISpecification<ServiceEstimatePrice> filterBySpec,
            ISpecification<ServiceEstimatePrice> orderBySpec
            );
        public Task<ServiceEstimatePrice> GetById(
            ISpecification<ServiceEstimatePrice> byIdSpec
            );
        public Task<ServiceEstimatePrice> GetByServiceEstimateId(
            ISpecification<ServiceEstimatePrice> byServiceEstimateIdSpec
            );
        public Task<ServiceEstimatePrice> Insert(
            ServiceEstimatePriceViewModel serviceEstimatePriceViewModel
            );
        public Task<ServiceEstimatePrice> Update(
            ISpecification<ServiceEstimatePrice> byIdSpec,
            ServiceEstimatePriceViewModel serviceEstimatePriceViewModel
            );
        public Task<ServiceEstimatePrice> Delete(
            ISpecification<ServiceEstimatePrice> byIdSpec
            );
    }
}
