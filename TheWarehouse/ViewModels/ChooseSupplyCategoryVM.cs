namespace TheWarehouse.ViewModels
{
    public class ChooseSupplyCategoryVM : Supplycategory
    {
        public ChooseSupplyCategoryVM() 
        {
            Supplycategories = [];
        }

        public ChooseSupplyCategoryVM(List<Supplycategory> supplyCategories)
        {
            Supplycategories = supplyCategories;
        }

        public ChooseSupplyCategoryVM(int menuitemid, List<Supplycategory> supplyCategories)
        {
            MenuitemId = menuitemid;
            Supplycategories = supplyCategories;
        }

        public int? MenuitemId;

        public List<Supplycategory> Supplycategories { get; set; }
    }
}
