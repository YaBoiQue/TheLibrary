using RapidTireEstimates.Models;
using RapidTireEstimates.Helpers;

namespace RapidTireEstimates.ViewModels
{
    public class ShopSupplyViewModel : ShopSupply
    {
        public ShopSupplyViewModel()
        {
            ShopSupplies = new List<ShopSupply>();

            ReturnController = "ShopSupplies";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        //Storage Variables

        //ShopSupply List
        public IEnumerable<ShopSupply> ShopSupplies { get; set; }

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
