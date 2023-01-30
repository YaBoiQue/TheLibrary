using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimateByServiceEstimateId : Specification<Estimate>
    {
        public GetEstimateByServiceEstimateId(int serviceEstimateId)
        {
            _ = Query.Where(e => e.Services.Any(s => s.Id == serviceEstimateId));
        }
    }
}
