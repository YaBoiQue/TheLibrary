namespace TheWarehouse.Specifications.Supply
{
    public class GetSuppliesOrderedBy : Specification<Models.Supply>
    {
        public GetSuppliesOrderedBy(SortByParameter SortBy)
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
