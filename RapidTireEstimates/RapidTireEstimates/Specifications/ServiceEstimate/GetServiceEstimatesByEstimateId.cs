using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimatesByEstimateId : Specification<ServiceEstimate>
    {
        public GetServiceEstimatesByEstimateId(int estimateId)
        {
            _ = Query.Where(s => s.EstimateId == estimateId);
        }
    }
}
