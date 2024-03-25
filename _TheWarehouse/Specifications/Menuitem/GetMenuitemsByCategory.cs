namespace TheWarehouse.Specifications.Menuitem
{
    public class GetMenuitemsByMenucategory : Specification<Models.Menuitem>
    {
        public GetMenuitemsByMenucategory(int MenucategoryId)
        {
            _ = Query.Where(m => m.MenucategoryId == MenucategoryId);
        }
    }
}
