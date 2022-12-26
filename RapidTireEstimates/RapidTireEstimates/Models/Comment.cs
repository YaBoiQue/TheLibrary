using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RapidTireEstimates.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Contents { get; set; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }


        public Comment()
        {
            this.DateCreated = DateTime.Now;
        }
    }
}
