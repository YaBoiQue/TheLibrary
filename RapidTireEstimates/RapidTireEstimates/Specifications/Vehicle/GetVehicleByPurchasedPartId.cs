using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehicleByPurchasedPartId : Specification<Vehicle>
    {
        public GetVehicleByPurchasedPartId(int purchasedPartId)
        {
            _ = Query.Where(v => v.ReplacedParts.Any(r => r.Id == purchasedPartId));
        }
    }
}
