using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimatePricesFilteredBy : Specification<ServiceEstimatePrice>
    {
        public GetServiceEstimatePricesFilteredBy(string filterBy)
        {
            _ = Query.Where(s => s.Comment == filterBy);
        }
    }
}
