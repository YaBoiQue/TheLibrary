using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetPurchasedPartsByEstimateId : Specification<PurchasedPart>
    {
        public GetPurchasedPartsByEstimateId(int estimateId)
        {
            Query.Where(p => p.EstimateId == estimateId);
        }
    }
}
