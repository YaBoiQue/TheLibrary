using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehicleTypeById : Specification<VehicleType>
    {
        public GetVehicleTypeById(int id)
        {
            _ = Query.Where(v => v.Id == id);
        }
    }
}
