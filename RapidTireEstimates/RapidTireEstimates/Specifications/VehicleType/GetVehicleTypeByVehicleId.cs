using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specification
{
    public class GetVehicleTypeByVehicleId : Specification<VehicleType>
    {
        public GetVehicleTypeByVehicleId(int vehicleId)
        {
            _ = Query.Where(t => t.Vehicles.Any(v => v.Id == vehicleId));
        }
    }
}
