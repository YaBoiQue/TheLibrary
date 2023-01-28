using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServicesByVehicleTypeId : Specification<Service>
    {
        public GetServicesByVehicleTypeId(int vehicleTypeId)
        {
            _ = Query.Where(v => v.VehicleTypes.SingleOrDefault(v => v.VehicleTypesId == vehicleTypeId).VehicleTypesId == vehicleTypeId);
        }
    }
}
