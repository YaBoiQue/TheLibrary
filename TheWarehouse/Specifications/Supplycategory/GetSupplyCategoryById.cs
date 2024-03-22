namespace TheWarehouse.Specifications.Supplycategory
{
    public class GetSupplycategoryById : Specification<Models.Supplycategory>
    {
        public GetSupplycategoryById(string type)
        {
            _ = Query.Where(c => c.Name == type);
        }
    }
}
