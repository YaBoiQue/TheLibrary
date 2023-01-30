using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehicleTypesFilteredBy : Specification<VehicleType>
    {
        public GetVehicleTypesFilteredBy(string filterBy)
        {
            _ = Query.Where(v => v.Name == filterBy);
        }
    }
}
