namespace TheWarehouse.Specifications.Transaction
{
    public class GetTransactionByTransactionitem : Specification<Models.Transaction>
    {
        public GetTransactionByTransactionitem(int transactionitemId) 
        {
            _ = Query.Where(c => c.Transactionitems.Any(m => m.TransactionItemId == transactionitemId));
        }
    }
}
