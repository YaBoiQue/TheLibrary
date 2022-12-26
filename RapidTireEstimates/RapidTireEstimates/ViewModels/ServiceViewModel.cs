using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RapidTireEstimates.Controllers;
using RapidTireEstimates.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace RapidTireEstimates.ViewModels
{
    public class ServiceViewModel
    {
        public ServiceViewModel() 
        {
            Prices = new List<ServicePrice>();
            VehicleTypes = new List<VehicleType>();
            ServiceEstimates = new List<ServiceEstimate>();
        }

        public ServiceViewModel(Service service)
        {
            if (service != null)
            {
                Id = service.Id;

            }

            Prices = new List<ServicePrice>();
            VehicleTypes = new List<VehicleType>();
            ServiceEstimates = new List<ServiceEstimate>();
        }

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,2)")]
        public decimal Hours { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }

        public IEnumerable<ServicePrice>? Prices { get; set; }
        public IEnumerable<VehicleType>? VehicleTypes { get; set; }
        public IEnumerable<ServiceEstimate>? ServiceEstimates { get; set; }

        public MultiSelectList VehicleTypeList { get; set; }
    }
}
