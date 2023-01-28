using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehicleTypesFilteredBy : Specification<VehicleType>
    {
        public GetVehicleTypesFilteredBy()
        {
            _ = Query;
        }
    }
}
