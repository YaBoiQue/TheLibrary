using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetCustomerCommentsFilteredBy : Specification<CustomerComment>
    {
        public GetCustomerCommentsFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Contents == filterBy);
            }
        }
    }
}
