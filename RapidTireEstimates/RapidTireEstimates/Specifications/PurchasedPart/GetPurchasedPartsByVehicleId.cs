using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetPurchasedPartsByVehicleId : Specification<PurchasedPart>
    {
        public GetPurchasedPartsByVehicleId(int vehicleId)
        {
            _ = Query.Where(p => p.VehicleId == vehicleId);
        }
    }
}
