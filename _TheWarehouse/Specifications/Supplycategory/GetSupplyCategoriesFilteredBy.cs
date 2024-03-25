namespace TheWarehouse.Specifications.Supplycategory
{
    public class GetSupplycategoriesFilteredBy : Specification<Models.Supplycategory>
    {
        public GetSupplycategoriesFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Name == filterBy);
            }
        }
    }
}
