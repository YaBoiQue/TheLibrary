namespace TheWarehouse.Specifications.Menucategory
{
    public class GetMenuCategoryById : Specification<Models.Menucategory>
    {
        public GetMenuCategoryById(int MenucategoryId)
        {
            _ = Query.Where(c => c.MenucategoryId == MenucategoryId);
        }
    }
}
