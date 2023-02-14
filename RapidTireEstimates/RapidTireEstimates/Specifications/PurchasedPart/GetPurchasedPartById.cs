using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetPurchasedPartById : Specification<PurchasedPart>
    {
        public GetPurchasedPartById(int purchasedPartId)
        {
            _ = Query.Where(p => p.Id == purchasedPartId);
        }
    }
}
