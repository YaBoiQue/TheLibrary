using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimateCommentByServiceEstimateId : Specification<ServiceEstimateComment>
    {
        public GetServiceEstimateCommentByServiceEstimateId(int serviceEstimateId)
        {
            _ = Query.Where(c => c.ServiceEstimateId== serviceEstimateId);
        }
    }
}
