using Ardalis.Specification;
using RapidTireEstimates.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{
    public class GetCustomersOrderedBy : Specification<Customer>
    {
        public GetCustomersOrderedBy(SortByParameter SortBy)
        {
            switch (SortBy)
            {
                case SortByParameter.NameDESC:
                    _ = Query.OrderByDescending(o => o.Name).ThenByDescending(o => o.PhoneNumber);
                    break;
                case SortByParameter.PhoneNumberDESC:
                    _ = Query.OrderByDescending(o => o.PhoneNumber).ThenByDescending(o => o.Name);
                    break;
                case SortByParameter.PhoneNumberASC:
                    _ = Query.OrderBy(o => o.PhoneNumber).ThenBy(o => o.Name);
                    break;
                default:
                    _ = Query.OrderBy(o => o.Name).ThenBy(o => o.PhoneNumber);
                    break;
            }
        }
    }
}
