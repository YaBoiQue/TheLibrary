
namespace TheWarehouse.ViewModels
{
    
    public class EditMenucategoryVM
    {
        public EditMenucategoryVM(Menucategory menucategory)
        {
            MenucategoryId = menucategory.MenucategoryId;
            Name = menucategory.Name;
        }
        public EditMenucategoryVM() { }

        public int MenucategoryId { get; set; }

        public string Name { get; set; }

        public byte[]? Image { get; set; }
    }
}
