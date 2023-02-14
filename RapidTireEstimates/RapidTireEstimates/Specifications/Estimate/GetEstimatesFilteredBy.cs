using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimatesFilteredBy : Specification<Estimate>
    {
        public GetEstimatesFilteredBy(string filterBy)
        {
        }
    }
}
