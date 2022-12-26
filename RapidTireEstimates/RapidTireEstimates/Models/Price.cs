using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Value { get; set; }
    }
}
