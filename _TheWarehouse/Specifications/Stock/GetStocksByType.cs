namespace TheWarehouse.Specifications.Stock
{
    public class GetStocksByType : Specification<Models.Stock>
    {
        public GetStocksByType(string type)
        {
            _ = Query.Where(i => i.Code == type);
        }
    }
}
