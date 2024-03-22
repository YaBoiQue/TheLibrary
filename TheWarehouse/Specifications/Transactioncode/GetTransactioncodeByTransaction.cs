namespace TheWarehouse.Specifications.Transactioncode
{
    public class GetTransactioncodeByTransaction : Specification<Models.Transactioncode>
    {
        public GetTransactioncodeByTransaction(int transactionId) 
        {
            _ = Query.Where(c => c.Transactions.Any(m => m.TransactionId == transactionId));
        }
    }
}
