using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimateByCommentId : Specification<ServiceEstimate>
    {
        public GetServiceEstimateByCommentId(int commentId)
        {
            _ = Query.Where(s => s.Comments.Any(c => c.Id == commentId));
        }
    }
}
