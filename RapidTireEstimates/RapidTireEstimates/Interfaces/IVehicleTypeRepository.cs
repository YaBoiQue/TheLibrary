using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IVehicleTypeRepository : IDisposable
    {
        public Task<List<VehicleType>> GetAll(
            ISpecification<VehicleType> filterBySpec,
            ISpecification<VehicleType> orderBySpec
            );
        public Task<List<VehicleType>> GetByServiceId(
            ISpecification<VehicleType> byServiceIdSpec,
            ISpecification<VehicleType> filterBySpec,
            ISpecification<VehicleType> orderBySpec
            );
        public Task<VehicleType> GetById(
            ISpecification<VehicleType> byIdSpec
            );
        public Task<VehicleType> GetByVehicleId(
            ISpecification<VehicleType> byVehicleIdSpec
            );
        public Task<VehicleType> Insert(
            VehicleTypeViewModel vehicleTypeViewModel
            );
        public Task<VehicleType> Update(
            ISpecification<VehicleType> byIdSpec,
            VehicleTypeViewModel vehicleTypeViewModel
            );
        public Task Delete(
            ISpecification<VehicleType> byIdSpec
            );

    }
}
