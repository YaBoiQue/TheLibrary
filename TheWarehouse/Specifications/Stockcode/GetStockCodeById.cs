namespace TheWarehouse.Specifications.Stockcode
{
    public class GetStockcodeById : Specification<Models.Stockcode>
    {
        public GetStockcodeById(string code)
        {
            _ = Query.Where(c => c.Code == code);
        }
    }
}
