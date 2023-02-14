using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimateCommentById : Specification<EstimateComment>
    {
        public GetEstimateCommentById(int estimateCommentId)
        {
            _ = Query.Where(e => e.Id == estimateCommentId);
        }
    }
}
