using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetCustomerCommentById : Specification<CustomerComment>
    {
        public GetCustomerCommentById(int commentId)
        {
            _ = Query.Where(c => c.Id == commentId);
        }
    }
}
