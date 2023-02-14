using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehicleById : Specification<Vehicle>
    {
        public GetVehicleById(int id)
        {
            _ = Query.Where(v => v.Id == id);
        }
    }
}
