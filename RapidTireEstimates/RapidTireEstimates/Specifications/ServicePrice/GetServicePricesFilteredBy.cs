using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServicePricesFilteredBy : Specification<ServicePrice>
    {
        public GetServicePricesFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Include(p => p.Service)
                    .Where(p => p.Description == filterBy);
            }
        }
    }
}
