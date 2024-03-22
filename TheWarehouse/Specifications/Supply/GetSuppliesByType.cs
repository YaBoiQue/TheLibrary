namespace TheWarehouse.Specifications.Supply
{
    public class GetSuppliesByType : Specification<Models.Supply>
    {
        public GetSuppliesByType(string type)
        {
            _ = Query.Where(s => s.Name == type);
        }
    }
}
