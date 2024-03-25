namespace TheWarehouse.Specifications.Supply
{
    public class GetSupplyByStock : Specification<Models.Supply>
    {
        public GetSupplyByStock(int StockId) 
        {
            _ = Query.Where(c => c.Stocks.Any(m => m.StockId == StockId));
        }
    }
}
