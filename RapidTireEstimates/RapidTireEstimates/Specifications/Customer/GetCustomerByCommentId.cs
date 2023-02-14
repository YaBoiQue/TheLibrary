using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetCustomerByCommentId : Specification<Customer>
    {
        public GetCustomerByCommentId(int commentId)
        {
            _ = Query.Where(c => c.Comments.Any(c => c.Id == commentId));
        }
    }
}
