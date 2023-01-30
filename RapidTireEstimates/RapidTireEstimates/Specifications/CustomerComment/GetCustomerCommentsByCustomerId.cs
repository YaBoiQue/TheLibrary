using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetCustomerCommentsByCustomerId : Specification<CustomerComment>
    {
        public GetCustomerCommentsByCustomerId(int customerId)
        {
            _ = Query.Where(c => c.CustomerId == customerId);
        }
    }
}
