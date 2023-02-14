using System.ComponentModel.DataAnnotations;

namespace RapidTireEstimates.Models
{
    public class Part : Price
    {
        [Required]
        [Display(Name = "Part Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}