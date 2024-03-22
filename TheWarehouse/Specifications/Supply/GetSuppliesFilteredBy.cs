namespace TheWarehouse.Specifications.Supply
{
    public class GetSuppliesFilteredBy : Specification<Models.Supply>
    {
        public GetSuppliesFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Name == filterBy);
            }
        }
    }
}
