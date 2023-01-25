using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IVehicleTypeRepository : IDisposable
    {
        public Task<List<VehicleType>> GetVehicleTypes(
            ISpecification<VehicleType> filterBySpec,
            ISpecification<VehicleType> orderBySpec);
        public Task<VehicleType> GetVehicleTypeById(ISpecification<VehicleType> byIdSpec);
        public Task<List<VehicleType>> GetVehicleTypesByServiceId(ISpecification<VehicleType> byServiceIdSpec);
        public Task<VehicleType> GetVehicleTypeByVehicleId(ISpecification<VehicleType> byVehicleIdSpec);
        public Task<VehicleType> InsertVehicleType(VehicleTypeViewModel vehicleTypeViewModel);
        public Task<VehicleType> UpdateVehicleType(ISpecification<VehicleType> byIdSpec,
            VehicleTypeViewModel vehicleTypeViewModel);
        public Task DeleteVehicleType(ISpecification<VehicleType> byIdSpec);

    }
}
