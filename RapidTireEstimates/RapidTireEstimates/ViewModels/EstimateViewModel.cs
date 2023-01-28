using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.ViewModels
{
    public class EstimateViewModel : Estimate
    {
        public EstimateViewModel()
        {
            Estimates = new List<Estimate>();

            ReturnController = "Estimates";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }
        
        //Storage Variables

        //Estimate List
        public IEnumerable<Estimate> Estimates { get; set; }

        //Return values(for address return feature)
        public string ReturnController { get; set; }
        public string ReturnAction { get; set; }
        public string ReturnId { get; set; }

        //Filter/Sort values(for filter/sort feature)
        public string FilterBy { get; set; }
        public SortByParameter SortBy { get; set; }
        public SortByParameter SortByLevel { get; set; }
        public SortByParameter SortByValue { get; set; }
    }
}
