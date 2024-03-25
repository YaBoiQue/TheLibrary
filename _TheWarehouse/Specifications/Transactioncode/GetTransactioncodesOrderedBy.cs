namespace TheWarehouse.Specifications.Transactioncode
{
    public class GetTransactioncodesOrderedBy : Specification<Models.Transactioncode>
    {
        public GetTransactioncodesOrderedBy(SortByParameter SortBy)
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
