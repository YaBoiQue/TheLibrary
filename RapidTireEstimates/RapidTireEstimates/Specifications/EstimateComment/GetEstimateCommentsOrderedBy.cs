using Ardalis.Specification;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimateCommentsOrderedBy : Specification<EstimateComment>
    {
        public GetEstimateCommentsOrderedBy(SortByParameter sortBy)
        {

            switch (sortBy)
            {
                case SortByParameter.DateDESC:
                    _ = Query.OrderByDescending(o => o.DateCreated).ThenByDescending(o => o.Contents);
                    break;
                case SortByParameter.ContentsDESC:
                    _ = Query.OrderByDescending(o => o.Contents).ThenByDescending(o => o.DateCreated);
                    break;
                case SortByParameter.ContentsASC:
                    _ = Query.OrderBy(o => o.Contents).ThenBy(o => o.DateCreated);
                    break;
                default:
                    _ = Query.OrderBy(o => o.DateCreated).ThenBy(o => o.Contents);
                    break;
            }
        }
    }
}
