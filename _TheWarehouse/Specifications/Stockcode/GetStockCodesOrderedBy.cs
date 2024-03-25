namespace TheWarehouse.Specifications.Stockcode
{
    public class GetStockcodesOrderedBy : Specification<Models.Stockcode>
    {
        public GetStockcodesOrderedBy(SortByParameter SortBy)
        {
            switch (SortBy)
            {
                case SortByParameter.NameDesc:
                    _ = Query.OrderByDescending(o => o.Code);
                    break;

                default:
                    _ = Query.OrderBy(o => o.Code);
                    break;
            }
        }
    }
}
