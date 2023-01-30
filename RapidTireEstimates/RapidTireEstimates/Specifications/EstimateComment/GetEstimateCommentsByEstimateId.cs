using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimateCommentsByEstimateId : Specification<EstimateComment>
    {
        public GetEstimateCommentsByEstimateId(int estimateId)
        {
            _ = Query.Where(e => e.EstimateId== estimateId);
        }
    }
}
