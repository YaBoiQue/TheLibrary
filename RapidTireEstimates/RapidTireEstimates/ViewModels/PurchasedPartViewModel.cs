using RapidTireEstimates.Models;
using RapidTireEstimates.Helpers;
using RapidTireEstimates.Controllers;

namespace RapidTireEstimates.ViewModels
{
    public class PurchasedPartViewModel : PurchasedPart
    {
        public PurchasedPartViewModel()
        {
            PurchasedPart = new PurchasedPart();
            PurchasedParts = new List<PurchasedPart>();

            ReturnController = "PurchasedParts";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        //Storage Variables
        public PurchasedPart PurchasedPart { get; set; }
        public IEnumerable<PurchasedPart> PurchasedParts { get; set; }

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
