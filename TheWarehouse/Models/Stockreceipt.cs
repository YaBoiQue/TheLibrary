using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace TheWarehouse.Models
{
    public class Stockreceipt
    {
        public int StockreceiptId { get; set; }
        public int SupplierId { get; set; }
        public DateTime DateTimePurchased { get; set; }
        public string? ImageName { get; set; }

        [NotMapped]
        [AllowNull]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }

        [NotMapped][AllowNull]
        public string? ImagePath { get; set; }

        [AllowNull]
        public DateTime Timestamp { get; set; }

        [AllowNull]
        public string? UserId { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        public virtual Supplier? Supplier { get; set; }
    }
}
