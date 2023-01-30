using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimateByCommentId : Specification<Estimate>
    {
        public GetEstimateByCommentId(int commentId)
        {
            _ = Query.Where(e => e.Comments.Any(c => c.Id == commentId));
        }
    }
}
