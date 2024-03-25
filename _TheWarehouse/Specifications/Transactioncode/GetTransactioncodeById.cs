namespace TheWarehouse.Specifications.Transactioncode
{
    public class GetTransactioncodeById : Specification<Models.Transactioncode>
    {
        public GetTransactioncodeById(string code)
        {
            _ = Query.Where(c => c.Code == code);
        }
    }
}
