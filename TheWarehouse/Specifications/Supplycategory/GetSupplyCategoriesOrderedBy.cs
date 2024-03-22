namespace TheWarehouse.Specifications.Supplycategory
{
    public class GetSupplycategoriesOrderedBy : Specification<Models.Supplycategory>
    {
        public GetSupplycategoriesOrderedBy(SortByParameter SortBy)
        {
            switch (SortBy)
            {
                case SortByParameter.NameDesc:
                    _ = Query.OrderByDescending(o => o.Name);
                    break;

                default:
                    _ = Query.OrderBy(o => o.Name);
                    break;
            }
        }
    }
}
