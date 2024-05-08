namespace TheWarehouse.ViewModels
{
    public class ChooseSupplyVM : Supplycategory
    {
        public ChooseSupplyVM() 
        {
            Supplies = [];
        }

        public ChooseSupplyVM(List<Supply> supplies)
        {
            Supplies = supplies;
        }

        public ChooseSupplyVM(int menuitemid, List<Supply> supplies)
        {
            MenuitemId = menuitemid;
            Supplies = supplies;
        }

        public int? MenuitemId;

        public List<Supply> Supplies { get; set; }
    }
}
