namespace TheWarehouse.Specifications.Supply
{
    public class GetSuppliesBySupplier : Specification<Models.Supply>
    {
        public GetSuppliesBySupplier(int supplierId)
        {
            _ = Query.Where(s => s.SupplierId == supplierId);
        }
    }
}
