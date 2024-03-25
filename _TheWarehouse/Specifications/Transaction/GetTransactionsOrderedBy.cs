namespace TheWarehouse.Specifications.Transaction
{
    public class GetTransactionsOrderedBy : Specification<Models.Transaction>
    {
        public GetTransactionsOrderedBy(SortByParameter SortBy)
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
