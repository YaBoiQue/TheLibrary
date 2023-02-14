using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimateById : Specification<Estimate>
    {
        public GetEstimateById(int estimateId)
        {
            _ = Query.Where(e => e.Id == estimateId);
        }
    }
}
