using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimateCommentsFilteredBy : Specification<EstimateComment>
    {
        public GetEstimateCommentsFilteredBy(string filterBy)
        {
            _ = Query.Where(e => e.Contents == filterBy);
        }
    }
}
