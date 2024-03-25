namespace TheWarehouse.Specifications.Transaction
{
    public class GetTransactionById : Specification<Models.Transaction>
    {
        public GetTransactionById(int transactionId)
        {
            _ = Query.Where(c => c.TransactionId == transactionId);
        }
    }
}
