namespace TheWarehouse.Specifications.Menucategory
{
    public class GetMenuCategoriesFilteredBy : Specification<Models.Menucategory>
    {
        public GetMenuCategoriesFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Name == filterBy);
            }
        }
    }
}
