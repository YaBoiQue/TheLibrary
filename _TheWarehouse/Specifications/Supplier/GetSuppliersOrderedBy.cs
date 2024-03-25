namespace TheWarehouse.Specifications.Suppkier
{
    public class GetSuppliersOrderedBy : Specification<Models.Supplier>
    {
        public GetSuppliersOrderedBy(SortByParameter SortBy)
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
