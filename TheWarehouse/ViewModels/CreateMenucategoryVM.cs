using System.ComponentModel;

namespace TheWarehouse.ViewModels
{
    
    public class CreateMenucategoryVM
    {
        public string Name { get; set; } = null!;

        [BindProperty]
        public IFormFile ImageData { get; set; }
    }
}
