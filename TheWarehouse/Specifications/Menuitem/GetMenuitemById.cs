namespace TheWarehouse.Specifications.Menuitem
{
    public class GetMenuitemById : Specification<Models.Menuitem>
    {
        public GetMenuitemById(int menuitemId)
        {
            _ = Query.Where(c => c.MenuItemId == menuitemId);
        }
    }
}
