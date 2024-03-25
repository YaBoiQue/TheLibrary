namespace TheWarehouse.Specifications.Transactionitem
{
    public class GetTransactionitemsByMenuitem : Specification<Models.Transactionitem>
    {
        public GetTransactionitemsByMenuitem(int menuitemId)
        {
            _ = Query.Where(t => t.MenuItemId == menuitemId);
        }
    }
}
