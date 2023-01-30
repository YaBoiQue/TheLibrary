using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetCustomerByVehicleId : Specification<Customer>
    {
        public GetCustomerByVehicleId(int vehicleId)
        {
            _ = Query.Where(c => c.Vehicles.Any(v => v.Id == vehicleId));
        }
    }
}
