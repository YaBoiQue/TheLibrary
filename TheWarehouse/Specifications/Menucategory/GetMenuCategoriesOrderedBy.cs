namespace TheWarehouse.Specifications.Menucategory
{
    public class GetMenuCategoriesOrderedBy : Specification<Models.Menucategory>
    {
        public GetMenuCategoriesOrderedBy(SortByParameter SortBy)
        {
            switch (SortBy)
            {
                case SortByParameter.NameDesc:
                    _ = Query.OrderByDescending(o => o.Name);
                    break;

                default:
                    _ = Query.OrderBy(o => o.Name);
                    break;
            }
        }
    }
}
