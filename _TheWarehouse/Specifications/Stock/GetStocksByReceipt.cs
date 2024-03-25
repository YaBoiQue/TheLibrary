namespace TheWarehouse.Specifications.Stock
{
    public class GetStocksByReceipt : Specification<Models.Stock>
    {
        public GetStocksByReceipt(int receiptId)
        {
            _ = Query.Where(i =>  i.ReceiptId == receiptId);
        }
    }
}
