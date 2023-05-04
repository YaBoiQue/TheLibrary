using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.ViewModels
{
    public class ServiceEstimateCommentViewModel : ServiceEstimateComment
    {
        public ServiceEstimateCommentViewModel()
        {
            ServiceEstimateComment = new ServiceEstimateComment();
            ServiceEstimateComments = new List<ServiceEstimateComment>();

            ReturnController = "ServiceEstimateComments";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        public ServiceEstimateCommentViewModel(ServiceEstimateCommentViewModel serviceEstimateCommentViewModel)
        {
            if (serviceEstimateCommentViewModel != null)
            {
                Id = serviceEstimateCommentViewModel.Id;
                Contents = serviceEstimateCommentViewModel.Contents;
                ServiceEstimateId = serviceEstimateCommentViewModel.ServiceEstimateId;
                ServiceEstimateId = serviceEstimateCommentViewModel.ServiceEstimateId;
                ServiceEstimateComments = serviceEstimateCommentViewModel.ServiceEstimateComments;
                ReturnController = serviceEstimateCommentViewModel.ReturnController;
                ReturnAction = serviceEstimateCommentViewModel.ReturnAction;
                ReturnId = serviceEstimateCommentViewModel.ReturnId;
                FilterBy = serviceEstimateCommentViewModel.FilterBy;
                SortBy = serviceEstimateCommentViewModel.SortBy;
                SortByLevel = serviceEstimateCommentViewModel.SortByLevel;
                SortByValue = serviceEstimateCommentViewModel.SortByValue;
            }

            ServiceEstimateComment ??= new ServiceEstimateComment();
            ServiceEstimateComments ??= new List<ServiceEstimateComment>();

            ReturnController ??= "ServiceEstimateComments";
            ReturnAction ??= "Index";
            ReturnId ??= "";
            FilterBy ??= "";
        }

        //Storage Variables
        public ServiceEstimateComment ServiceEstimateComment { get; set; }
        public IEnumerable<ServiceEstimateComment> ServiceEstimateComments { get; set; }

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
