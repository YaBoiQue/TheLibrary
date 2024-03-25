namespace TheWarehouse.Specifications.Menuitem
{
    public class GetMenuitemsOrderedBy : Specification<Models.Menuitem>
    {
        public GetMenuitemsOrderedBy(SortByParameter SortBy)
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
