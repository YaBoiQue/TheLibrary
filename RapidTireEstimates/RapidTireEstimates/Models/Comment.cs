using System.ComponentModel.DataAnnotations;

namespace RapidTireEstimates.Models
{
    public class Comment
    {
        public Comment()
        {
            Contents = "";
            DateCreated = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Contents")]
        public string Contents { get; set; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
    }
}
