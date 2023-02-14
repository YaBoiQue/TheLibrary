using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimatesByCustomerId : Specification<Estimate>
    {
        public GetEstimatesByCustomerId(int customerId)
        {
            _ = Query.Where(e => e.CustomerId == customerId);
        }
    }
}
