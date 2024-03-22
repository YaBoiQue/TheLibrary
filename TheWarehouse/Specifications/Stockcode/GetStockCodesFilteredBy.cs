namespace TheWarehouse.Specifications.Stockcode
{
    public class GetStockcodesFilteredBy : Specification<Models.Stockcode>
    {
        public GetStockcodesFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Code == filterBy);
            }
        }
    }
}
