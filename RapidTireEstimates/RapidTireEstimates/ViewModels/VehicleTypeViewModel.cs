using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.ViewModels
{
    public class VehicleTypeViewModel : VehicleType
    {
        public VehicleTypeViewModel()
        {
            VehicleType = new VehicleType();
            VehicleTypes = new List<VehicleType>();

            ReturnController = "VehicleTypes";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        public VehicleTypeViewModel(VehicleType vehicleType)
        {
            if (vehicleType != null)
            {
                Name = vehicleType.Name;
                Vehicles = vehicleType.Vehicles;
                Services = vehicleType.Services;
            }

            VehicleType = new VehicleType();
            VehicleTypes = new List<VehicleType>();

            ReturnController = "VehicleTypes";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        //Storage Variables
        public VehicleType VehicleType { get; set; }

        //VehicleType List
        public IEnumerable<VehicleType> VehicleTypes { get; set; }

        //Return Address Values (for dynamic return feature)
        public string ReturnController { get; set; }
        public string ReturnAction { get; set; }
        public string ReturnId { get; set; }

        //Filter/Sort Values (for filter/sort feature)
        public string FilterBy { get; internal set; }
        public SortByParameter SortBy { get; set; }
        public SortByParameter SortByName { get; set; }
        public SortByParameter SortByDescription { get; set; }
    }
}
