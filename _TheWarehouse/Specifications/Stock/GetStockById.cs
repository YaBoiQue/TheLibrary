namespace TheWarehouse.Specifications.Stock
{
    public class GetStockById : Specification<Models.Stock>
    {
        public GetStockById(int StockId)
        {
            _ = Query.Where(c => c.StockId == StockId);
        }
    }
}
