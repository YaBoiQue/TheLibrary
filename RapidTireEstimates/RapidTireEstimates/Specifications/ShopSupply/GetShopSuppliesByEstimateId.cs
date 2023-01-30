using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetShopSuppliesByEstimateId : Specification<ShopSupply>
    {
        public GetShopSuppliesByEstimateId(int estimateId)
        {
            _ = Query.Where(s => s.Estimates.Any(e => e.EstimateId == estimateId));
        }
    }
}
