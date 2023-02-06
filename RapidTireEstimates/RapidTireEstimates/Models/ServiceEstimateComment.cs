using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServiceEstimateComment : Comment
    {
        public ServiceEstimateComment()
        {
            ServiceEstimate = new ServiceEstimate();
        }

        public ServiceEstimateComment(ServiceEstimateCommentViewModel serviceEstimateCommentViewModel)
        {
            if (serviceEstimateCommentViewModel != null)
            {
                Id = serviceEstimateCommentViewModel.Id;
                Contents = serviceEstimateCommentViewModel.Contents;
                DateCreated = serviceEstimateCommentViewModel.DateCreated;
                ServiceEstimateId = serviceEstimateCommentViewModel.ServiceEstimateId;
                ServiceEstimate = serviceEstimateCommentViewModel.ServiceEstimate;
            }

            ServiceEstimate ??= new ServiceEstimate();
        }

        [ForeignKey("ServiceEstimate")]
        public int ServiceEstimateId { get; set; }

        public virtual ServiceEstimate ServiceEstimate { get; set; }
    }
}
