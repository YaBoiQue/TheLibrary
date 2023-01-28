using RapidTireEstimates.Models;
using RapidTireEstimates.Helpers;

namespace RapidTireEstimates.ViewModels
{
    public class VehicleViewModel : Vehicle
    {
        public VehicleViewModel()
        {
            Vehicles = new List<Vehicle>();

            ReturnController = "Vehicles";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        //Storage Variables

        //Vehicle List
        public IEnumerable<Vehicle> Vehicles { get; set; }

        //Return values(for address return feature)
        public string ReturnController { get; set; }
        public string ReturnAction { get; set; }
        public string ReturnId { get; set; }

        //Filter/Sort values(for filter/sort feature)
        public string FilterBy { get; set; }
        public Constants.SortByParameter SortBy { get; set; }
        public Constants.SortByParameter SortByLevel { get; set; }
        public Constants.SortByParameter SortByValue { get; set; }
    }
}
