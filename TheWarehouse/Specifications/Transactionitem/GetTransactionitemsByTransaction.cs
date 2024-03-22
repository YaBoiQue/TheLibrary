namespace TheWarehouse.Specifications.Transactionitem
{
    public class GetTransactionitemsByTransaction : Specification<Models.Transactionitem>
    {
        public GetTransactionitemsByTransaction(int transactionId) 
        {
            _ = Query.Where(c => c.TransactionId == transactionId);
        }
    }
}
