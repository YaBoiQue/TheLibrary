using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimateCommentsFilteredBy : Specification<ServiceEstimateComment>
    {
        public GetServiceEstimateCommentsFilteredBy(string filterBy)
        {
            _ = Query.Where(c => c.Contents == filterBy);
        }
    }
}
