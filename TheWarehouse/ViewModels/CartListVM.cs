namespace TheWarehouse.ViewModels
{
    public class CartListVM
    {
        public CartListVM() {}
        public CartListVM(List<Cartitem> cartitems)
        {
            Cartitems = cartitems;
        }
        public List<Cartitem> Cartitems { get; set; } = [];
        public Cartitem Cartitem { get; set; } = new();
        [DataType(DataType.Currency)]
        public decimal Total { get; set; } = 0;
    }
}
