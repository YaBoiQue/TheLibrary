using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetCustomerByEstimateId : Specification<Customer>
    {
        public GetCustomerByEstimateId(int estimateId)
        {
            _ = Query.Where(c => c.Estimates.Any(e => e.Id == estimateId));
        }
    }
}
