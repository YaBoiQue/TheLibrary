namespace TheWarehouse.Specifications.Supplier
    //CHANGE THIS NAMESPACE AND ALL BELOW
{
    public class GetSuppliersFilteredBy : Specification<Models.Supplier>
    {
        public GetSuppliersFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Name == filterBy);
            }
        }
    }
}
