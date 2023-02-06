using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class EstimateComment : Comment
    {
        public EstimateComment()
        {
            Estimate = new Estimate();
        }

        public EstimateComment(EstimateCommentViewModel estimateCommentViewModel)
        {
            if (estimateCommentViewModel != null)
            {
                Contents = estimateCommentViewModel.Contents;
                Id = estimateCommentViewModel.Id;
                EstimateId = estimateCommentViewModel.EstimateId;
                DateCreated = estimateCommentViewModel.DateCreated;
                Estimate = estimateCommentViewModel.Estimate;
            }

            Estimate ??= new Estimate();
        }

        [ForeignKey("Estimate")]
        public int EstimateId { get; set; }

        public virtual Estimate Estimate { get; set; }
    }
}