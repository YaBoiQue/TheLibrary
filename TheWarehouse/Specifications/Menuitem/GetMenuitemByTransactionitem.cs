namespace TheWarehouse.Specifications.Menuitem
{
    public class GetMenuitemByTransactionitem : Specification<Models.Menuitem>
    {
        public GetMenuitemByTransactionitem(int transactionitemId) 
        {
            _ = Query.Where(c => c.Transactionitems.Any(m => m.TransactionItemId == transactionitemId));
        }
    }
}
