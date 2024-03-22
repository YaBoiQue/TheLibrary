namespace TheWarehouse.ViewModels
{
    public partial class MenuPriceTotal
    {
        public int MenuitemId { get; set; }
        public string Name { get; set; } = null!;
        public decimal? MenuPrice { get; set; }
        public string MenucategoryId { get; set; } = null!;
        public decimal? Total {  get; set; }

        public MenuPriceTotal() { }
    }
}
