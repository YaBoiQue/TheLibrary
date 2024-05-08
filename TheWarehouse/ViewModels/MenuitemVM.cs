namespace TheWarehouse.ViewModels
{
    public class MenuitemVM : Menuitem
    {
        public MenuitemVM()
        {
            menuitems = [];
        }
        public MenuitemVM(ICollection<Menuitem> menuitems)
        {
            this.menuitems = menuitems;
        }

        public ICollection<Menuitem> menuitems { get; set; } = null!;
    }
}
