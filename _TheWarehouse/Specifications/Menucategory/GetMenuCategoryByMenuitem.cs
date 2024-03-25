namespace TheWarehouse.Specifications.Menucategory
{
    public class GetMenuCategoryByMenuitem : Specification<Models.Menucategory>
    {
        public GetMenuCategoryByMenuitem(int menuitemId) 
        {
            _ = Query.Where(c => c.Menuitems.Any(m => m.MenuItemId == menuitemId));
        }
    }
}
