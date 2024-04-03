namespace TheWarehouse.ViewModels
{
    public class MenuitemViewModel : Menuitem
    {
        public MenuitemViewModel()
        {
            menuitems = [];
        }
        public MenuitemViewModel(ICollection<Menuitem> menuitems)
        {
            this.menuitems = menuitems;
        }

        public ICollection<Menuitem> menuitems { get; set; } = null!;
    }
}
