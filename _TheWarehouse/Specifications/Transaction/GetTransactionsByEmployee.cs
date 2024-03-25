namespace TheWarehouse.Specifications.Transaction
{
    public class GetTransactionsByUser : Specification<Models.Transaction>
    {
        public GetTransactionsByUser(string userId)
        {
            _ = Query.Where(t => t.UserId == userId);
        }
    }
}
