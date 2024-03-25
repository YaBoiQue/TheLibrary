namespace TheWarehouse.Specifications.Stock
{
    public class GetStocksbySupply : Specification<Models.Stock>
    {
        public GetStocksbySupply(int supplyId)
        {
            _ = Query.Where(i => i.SupplyId == supplyId);
        }
    }
}
