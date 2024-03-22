namespace TheWarehouse.Specifications.Supply
{
    public class GetSupplyById : Specification<Models.Supply>
    {
        public GetSupplyById(int supplyId)
        {
            _ = Query.Where(c => c.SupplyId == supplyId);
        }
    }
}
