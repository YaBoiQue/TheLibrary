using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetCustomerById : Specification<Customer>
    {
        public GetCustomerById(int customerId)
        {
            _ = Query.Where(c => c.Id == customerId);
        }
    }
}
