namespace TheWarehouse.Specifications.Stock
{
    public class GetStocksByUser : Specification<Models.Stock>
    {
        public GetStocksByUser(string employeeId) 
        {
            _ = Query.Where(c => c.UserId == employeeId);
        }
    }
}
