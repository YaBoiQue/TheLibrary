using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimateByVehicleId : Specification<Estimate>
    {
        public GetEstimateByVehicleId(int vehicleId)
        {
            _ = Query.Where(e => e.VehicleId == vehicleId);
        }
    }
}
