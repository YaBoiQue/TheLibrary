using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IServiceRepository : IDisposable
    {
        public Task<List<Service>> GetAll(
            ISpecification<Service> filterBySpec, 
            ISpecification<Service> orderBySpec
            );
        public Task<List<Service>> GetByVehicleTypeId(
            ISpecification<Service> byServiceVehicleIdSpec,
            ISpecification<Service> filterBySpec,
            ISpecification<Service> orderBySpec
            );
        public Task<Service> GetById(
            ISpecification<Service> byIdSpec
            );
        public Task<Service> GetByPriceId(
            ISpecification<Service> byPriceIdSpec
            );
        public Task<Service> GetByServiceEstimateId(
            ISpecification<Service> byIdServiceEstimateSpec
            );
        public Task<Service> Insert(
            ServiceViewModel serviceViewModel
            );
        public Task<Service> Update(
            ISpecification<Service> byIdSpec, 
            ServiceViewModel serviceViewModel
            );
        public Task Delete(
            ISpecification<Service> byIdSpec
            );
    }
}