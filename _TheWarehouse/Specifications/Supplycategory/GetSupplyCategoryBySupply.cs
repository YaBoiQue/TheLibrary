namespace TheWarehouse.Specifications.Supplycategory
{
    public class GetSupplycategoryBySupply : Specification<Models.Supplycategory>
    {
        public GetSupplycategoryBySupply(int supplyId) 
        {
            _ = Query.Where(c => c.Supplies.Any(m => m.SupplyId == supplyId));
        }
    }
}
