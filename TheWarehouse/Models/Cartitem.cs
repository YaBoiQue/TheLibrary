namespace TheWarehouse.Models
{
    public class Cartitem
    {
        public Cartitem()
        {
            Menuitem = new();
        }
        public Cartitem(Menuitem menuitem)
        {
            Menuitem = menuitem;
            Quantity = 1;
        }
        public Cartitem (Menuitem menuitem, int quantity)
        {
            Menuitem = menuitem;
            Quantity = quantity;
        }
        public Menuitem Menuitem { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Total { get; set; }
    }
}
