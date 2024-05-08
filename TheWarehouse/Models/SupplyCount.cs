namespace TheWarehouse.Models
{
    public class SupplyCount
    {
        public int SupplyId { get; set; }

        [Display(Name = "Supply Name")]
        public string Name { get; set; } = null!;

        public int Count { get; set; }

        public int SupplyCategoryId { get; set; }

        public int? SupplierId { get; set; }

        public virtual Supplier? Supplier { get; set; }

        public virtual Supplycategory SupplyCategory { get; set; } = null!;
    }
}
