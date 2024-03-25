namespace TheWarehouse.Specifications.Transactioncode
{
    public class GetTransactioncodesFilteredBy : Specification<Models.Transactioncode>
    {
        public GetTransactioncodesFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Code == filterBy);
            }
        }
    }
}
