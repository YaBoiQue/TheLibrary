namespace TheWarehouse.Specifications.Transaction
{
    public class GetTransactionsByType : Specification<Models.Transaction>
    {
        public GetTransactionsByType(string type)
        {
            _ = Query.Where(t => t.Code == type);
        }
    }
}
