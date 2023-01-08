using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IServicePriceRepository : IDisposable
    {

        public Task<List<ServicePrice>> GetServicePrices(ISpecification<ServicePrice> filterBySpec, ISpecification<ServicePrice> orderBySpec);
        public Task<ServicePrice> GetServicePriceById(ISpecification<ServicePrice> byIdSpec);
        public Task<List<ServicePrice>> GetServicePricesByServiceId(ISpecification<ServicePrice> byServiceIdSpec);
        public Task<ServicePrice> InsertServicePrice(ServicePriceViewModel servicePriceViewModel);
        public Task<ServicePrice> UpdateServicePrice(ISpecification<ServicePrice> byIdSpec, ServicePriceViewModel servicePriceViewModel);
        public Task DeleteServicePrice(ISpecification<ServicePrice> byIdSpec);
    }
}
