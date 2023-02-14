using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetCustomersFilteredBy : Specification<Customer>
    {
        public GetCustomersFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Name == filterBy);
            }
        }
    }
}
