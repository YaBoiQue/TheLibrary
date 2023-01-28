using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IVehicleRepository : IDisposable
    {
        public Task<List<Vehicle>> GetAll(
            ISpecification<Vehicle> filterBySpec,
            ISpecification<Vehicle> orderBySpec
            );
        public Task<List<Vehicle>> GetByCustomerId(
            ISpecification<Vehicle> byCustomerIdSpec,
            ISpecification<Vehicle> filterBySpec,
            ISpecification<Vehicle> orderBySpec
            );
        public Task<List<Vehicle>> GetByVehicleTypeId(
            ISpecification<Vehicle> byVehicleIdSpec,
            ISpecification<Vehicle> filterBySpec,
            ISpecification<Vehicle> orderBySpec
            );
        public Task<Vehicle> GetById(
            ISpecification<Vehicle> byIdSpec
            );
        public Task<Vehicle> GetByEstimateId(
            ISpecification<Vehicle> byEstimateIdSpec
            );
        public Task<Vehicle> GetByPurchasedPartId(
            ISpecification<Vehicle> byPurchasedPartIdSpec
            );
        public Task<Vehicle> Insert(
            VehicleViewModel vehicleViewModel
            );
        public Task<Vehicle> Update(
            ISpecification<Vehicle> byIdSpec,
            VehicleViewModel vehicleViewModel
            );
        public Task Delete(
            ISpecification<Vehicle> byIdSpec
            );
    }
}
