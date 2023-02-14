using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehiclesByVehicleTypeId : Specification<Vehicle>
    {
        public GetVehiclesByVehicleTypeId(int vehicleTypeId)
        {
            _ = Query.Where(v => v.VehicleTypeId == vehicleTypeId);
        }
    }
}
