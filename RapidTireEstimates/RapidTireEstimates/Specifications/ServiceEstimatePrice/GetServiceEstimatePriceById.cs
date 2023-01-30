using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimatePriceById : Specification<ServiceEstimatePrice>
    {
        public GetServiceEstimatePriceById(int id)
        {
            _ = Query.Where(s => s.Id == id);
        }
    }
}
