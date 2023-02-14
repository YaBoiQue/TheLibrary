using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetVehiclesByCustomerId : Specification<Vehicle>
    {
        public GetVehiclesByCustomerId(int customerId)
        {
            _ = Query.Where(v => v.CustomerId == customerId);
        }
    }
}
