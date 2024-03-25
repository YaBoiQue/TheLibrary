namespace TheWarehouse.Specifications.Menuitem
{
    public class GetMenuitemsFilteredBy : Specification<Models.Menuitem>
    {
        public GetMenuitemsFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Name == filterBy);
            }
        }
    }
}
