using System.ComponentModel.DataAnnotations;

namespace RapidTireEstimates.Models
{
    public class Part : Price
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}