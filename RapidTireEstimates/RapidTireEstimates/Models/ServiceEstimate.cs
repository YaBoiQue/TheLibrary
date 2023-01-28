using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServiceEstimate
    {
        public ServiceEstimate()
        {
            DateCreated = DateTime.Now;

            Estimate = new Estimate();
            Service = new Service();
            Price = new ServiceEstimatePrice();
            Comments = new List<ServiceEstimateComment>();
        }

        public ServiceEstimate(ServiceEstimate serviceEstimate)
        {
            if (serviceEstimate != null)
            {
                Id = serviceEstimate.Id;
                ServiceId = serviceEstimate.ServiceId;
                EstimateId = serviceEstimate.EstimateId;
                AdjustedHours = serviceEstimate.AdjustedHours;
                Estimate = serviceEstimate.Estimate;
                Service = serviceEstimate.Service;
                Price = serviceEstimate.Price;
                Comments = serviceEstimate.Comments;
                DateCreated = serviceEstimate.DateCreated;
            }

            DateCreated ??= DateTime.Now;

            Estimate ??= new Estimate();
            Service ??= new Service();
            Price ??= new ServiceEstimatePrice();
            Comments ??= new List<ServiceEstimateComment>();
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        [ForeignKey("Estimate")]
        public int EstimateId { get; set; }
        [ForeignKey("ServiceEstimatePrice")]
        public int PriceId { get; set; }

        [Display(Name = "Adjusted Flat-Rate Time")]
        public int AdjustedHours { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Creation Date")]
        public DateTime? DateCreated { get; set; }

        public virtual Estimate Estimate { get; set; }
        public virtual Service Service { get; set; }
        public virtual ServiceEstimatePrice Price { get; set; }
        public IEnumerable<ServiceEstimateComment> Comments { get; set; }
    }
}
