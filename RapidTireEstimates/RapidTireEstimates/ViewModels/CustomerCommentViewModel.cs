using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.ViewModels
{
    public class CustomerCommentViewModel : CustomerComment
    {
        public CustomerCommentViewModel()
        {
            CustomerComment = new CustomerComment();
            CustomerComments = new List<CustomerComment>();

            ReturnController = "CustomerComments";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        public CustomerCommentViewModel(CustomerCommentViewModel customerCommentViewModel)
        {
            if (customerCommentViewModel != null)
            {
                Id = customerCommentViewModel.Id;
                Contents = customerCommentViewModel.Contents;
                CustomerId = customerCommentViewModel.CustomerId;
                Customer = customerCommentViewModel.Customer;
                CustomerComment = customerCommentViewModel.CustomerComment;
                CustomerComments = customerCommentViewModel.CustomerComments;
                ReturnController = customerCommentViewModel.ReturnController;
                ReturnAction = customerCommentViewModel.ReturnAction;
                ReturnId = customerCommentViewModel.ReturnId;
                FilterBy = customerCommentViewModel.FilterBy;
                SortBy = customerCommentViewModel.SortBy;
                SortByLevel = customerCommentViewModel.SortByLevel;
                SortByValue = customerCommentViewModel.SortByValue;
            }

            CustomerComment ??= new CustomerComment();
            CustomerComments ??= new List<CustomerComment>();

            ReturnController ??= "CustomerComments";
            ReturnAction ??= "Index";
            ReturnId ??= "";
            FilterBy ??= "";
        }

        //Storage Variables
        public CustomerComment CustomerComment { get; set; }
        public IEnumerable<CustomerComment> CustomerComments { get; set; }

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
