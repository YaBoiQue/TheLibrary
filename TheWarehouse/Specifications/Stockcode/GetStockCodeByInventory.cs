namespace TheWarehouse.Specifications.Stockcode
{
    public class GetStockcodeByStock : Specification<Models.Stockcode>
    {
        public GetStockcodeByStock(int StockId) 
        {
            _ = Query.Where(c => c.Stocks.Any(m => m.StockId == StockId));
        }
    }
}
