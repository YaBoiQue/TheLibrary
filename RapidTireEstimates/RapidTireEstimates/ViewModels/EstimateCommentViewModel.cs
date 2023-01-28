using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.ViewModels
{
    public class EstimateCommentViewModel : EstimateComment
    {
        public EstimateCommentViewModel()
        {
            EstimateComments = new List<EstimateComment>();

            ReturnController = "EstimateComments";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        public EstimateCommentViewModel(EstimateCommentViewModel estimateCommentViewModel)
        {
            if (estimateCommentViewModel != null)
            {
                Id = estimateCommentViewModel.Id;
                Contents = estimateCommentViewModel.Contents;
                EstimateId = estimateCommentViewModel.EstimateId;
                EstimateId = estimateCommentViewModel.EstimateId;
                EstimateComments = estimateCommentViewModel.EstimateComments;
                ReturnController = estimateCommentViewModel.ReturnController;
                ReturnAction = estimateCommentViewModel.ReturnAction;
                ReturnId = estimateCommentViewModel.ReturnId;
                FilterBy = estimateCommentViewModel.FilterBy;
                SortBy = estimateCommentViewModel.SortBy;
                SortByLevel = estimateCommentViewModel.SortByLevel;
                SortByValue = estimateCommentViewModel.SortByValue;
            }

            EstimateComments ??= new List<EstimateComment>();

            ReturnController ??= "EstimateComments";
            ReturnAction ??= "Index";
            ReturnId ??= "";
            FilterBy ??= "";
        }

        //Storage Variables

        //EstimateComment List
        public IEnumerable<EstimateComment> EstimateComments { get; set; }

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
