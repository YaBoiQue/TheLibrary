using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimateByPriceId : Specification<ServiceEstimate>
    {
        public GetServiceEstimateByPriceId(int priceId)
        {
            _ = Query.Where(s => s.PriceId == priceId);
        }
    }
}
