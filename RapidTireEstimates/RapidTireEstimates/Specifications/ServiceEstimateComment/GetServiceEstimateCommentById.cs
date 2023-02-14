using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimateCommentById : Specification<ServiceEstimateComment>
    {
        public GetServiceEstimateCommentById(int commentId)
        {
            _ = Query.Where(c => c.Id== commentId);
        }
    }
}
