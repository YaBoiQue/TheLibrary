namespace TheWarehouse.Specifications.Stock
{
    public class GetStocksFilteredBy : Specification<Models.Stock>
    {
        public GetStocksFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Code == filterBy);
            }
        }
    }
}
