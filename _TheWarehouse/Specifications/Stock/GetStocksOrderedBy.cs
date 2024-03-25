namespace TheWarehouse.Specifications.Stock
{
    public class GetStocksOrderedBy : Specification<Models.Stock>
    {
        public GetStocksOrderedBy(SortByParameter SortBy)
        {
            switch (SortBy)
            {
                case SortByParameter.TimeDesc:
                    _ = Query.OrderByDescending(o => o.Timestamp);
                    break;

                default:
                    _ = Query.OrderBy(o => o.Timestamp);
                    break;
            }
        }
    }
}
