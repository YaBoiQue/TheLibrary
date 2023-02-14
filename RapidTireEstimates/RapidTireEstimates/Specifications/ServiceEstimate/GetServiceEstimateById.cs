using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimateById : Specification<ServiceEstimate>
    {
        public GetServiceEstimateById(int id)
        {
            _ = Query.Where(s => s.Id == id);
        }
    }
}
