using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IServicePriceRepository : IDisposable
    {

        public Task<List<ServicePrice>> GetAll(
            ISpecification<ServicePrice> filterBySpec, 
            ISpecification<ServicePrice> orderBySpec
            );
        public Task<List<ServicePrice>> GetByServiceId(
            ISpecification<ServicePrice> byServiceIdSpec,
            ISpecification<ServicePrice> filterBySpec,
            ISpecification<ServicePrice> orderBySpec
            );
        public Task<ServicePrice> GetById(
            ISpecification<ServicePrice> byIdSpec
            );
        public Task<ServicePrice> Insert(
            ServicePriceViewModel servicePriceViewModel
            );
        public Task<ServicePrice> Update(
            ISpecification<ServicePrice> byIdSpec, 
            ServicePriceViewModel servicePriceViewModel
            );
        public Task Delete(
            ISpecification<ServicePrice> byIdSpec
            );
    }
}
