using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehicleByEstimateId : Specification<Vehicle>
    {
        public GetVehicleByEstimateId(int estimateId)
        {
            _ = Query.Where(v => v.Estimates.Any(e => e.Id == estimateId));
        }
    }
}
