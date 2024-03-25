namespace TheWarehouse.Specifications.Supplier
{
    public class GetSupplierBySupply : Specification<Models.Supplier>
    {
        public GetSupplierBySupply(int supplyId) 
        {
            _ = Query.Where(c => c.Supplies.Any(m => m.SupplyId == supplyId));
        }
    }
}
