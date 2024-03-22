namespace TheWarehouse.Specifications.Transactionitem
{
    public class GetTransactionitemById : Specification<Models.Transactionitem>
    {
        public GetTransactionitemById(int transactionitemId)
        {
            _ = Query.Where(c => c.TransactionItemId == transactionitemId);
        }
    }
}
