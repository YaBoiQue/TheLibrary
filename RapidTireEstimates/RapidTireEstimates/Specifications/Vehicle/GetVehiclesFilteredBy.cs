using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehiclesFilteredBy : Specification<Vehicle>
    {
        public GetVehiclesFilteredBy(string filterBy)
        {
            _ = Query.Where(v => v.Make == filterBy || v.Model == filterBy);
        }
    }
}
