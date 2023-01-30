using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehicleTypesByServiceId : Specification<VehicleType>
    {
        public GetVehicleTypesByServiceId(int serviceId)
        {
            _ = Query.Where(v => v.Services.Any(s => s.Id == serviceId));
        }
    }
}
