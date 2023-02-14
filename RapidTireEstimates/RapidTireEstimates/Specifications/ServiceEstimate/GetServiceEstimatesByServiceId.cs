using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimatesByServiceId : Specification<ServiceEstimate>
    {
        public GetServiceEstimatesByServiceId(int serviceId)
        {
            _ = Query.Where(s => s.ServiceId == serviceId);
        }
    }
}
