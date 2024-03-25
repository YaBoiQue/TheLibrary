namespace TheWarehouse.Specifications.Supplier
{
    public class GetSupplierById : Specification<Models.Supplier>
    {
        public GetSupplierById(int supplierId)
        {
            _ = Query.Where(c => c.SupplierId == supplierId);
        }
    }
}
