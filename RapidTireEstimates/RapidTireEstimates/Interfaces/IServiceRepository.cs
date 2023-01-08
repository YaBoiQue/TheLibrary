using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IServiceRepository : IDisposable
    {
        public Task<List<Service>> GetServices(ISpecification<Service> filterBySpec, ISpecification<Service> orderBySpec);
        public Task<Service> GetServiceById(ISpecification<Service> byIdSpec);
        public Task<List<Service>> GetServicesByName(ISpecification<Service> byNameSpec, ISpecification<Service> filterBySpec, ISpecification<Service> orderBySpec);
        public Task<List<Service>> GetServicesByVehicleTypeId(ISpecification<Service> byServiceVehicleIdSpec, ISpecification<Service> filterBySpec, ISpecification<Service> orderBySpec);
        public Task<Service> GetServiceByServiceEstimateId(ISpecification<Service> byIdServiceEstimateSpec);
        public Task<Service> InsertService(ServiceViewModel serviceViewModel);
        public Task<Service> UpdateService(ISpecification<Service> byIdSpec, ServiceViewModel serviceViewModel);
        public Task DeleteService(ISpecification<Service> byIdSpec);

        public Task<List<VehicleType>> GetVehicleTypes();
    }
}