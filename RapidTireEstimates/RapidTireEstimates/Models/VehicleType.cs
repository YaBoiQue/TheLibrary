using RapidTireEstimates.Models.Linkers;
using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace RapidTireEstimates.Models
{
    public class VehicleType
    {
        public VehicleType()
        {
            Name = "";
            Vehicles = new List<Vehicle>();
            Services = new List<ServiceVehicleType>();
        }
        public VehicleType(VehicleType vehicleType)
        {
            if (vehicleType != null)
            {
                Name = vehicleType.Name;
                Vehicles = vehicleType.Vehicles;
                Services = vehicleType.Services;
            }

            Name ??= "";
            Vehicles ??= new List<Vehicle>();
            Services ??= new List<ServiceVehicleType>();
        }
        public VehicleType(VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (vehicleTypeViewModel != null)
            {
                Id = vehicleTypeViewModel.Id;
                Name = vehicleTypeViewModel.Name;
                Vehicles = vehicleTypeViewModel.Vehicles;
                Services = vehicleTypeViewModel.Services;
            }
            Name ??= "";

            Vehicles ??= new List<Vehicle>();
            Services ??= new List<ServiceVehicleType>();
        }
        public VehicleType(string name)
        {
            Name = name;
            Vehicles = new List<Vehicle>();
            Services = new List<ServiceVehicleType>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
        public string Name { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<ServiceVehicleType> Services { get; set; }

    }
}