using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimatesFilteredBy : Specification<ServiceEstimate>
    {
        public GetServiceEstimatesFilteredBy(string filterBy)
        {
        }
    }
}
