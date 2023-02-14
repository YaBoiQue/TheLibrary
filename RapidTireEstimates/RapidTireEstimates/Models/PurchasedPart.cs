using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class PurchasedPart : Part
    {
        public PurchasedPart()
        {
            Estimate = new Estimate();
            Vehicle = new Vehicle();
        }

        public PurchasedPart(PurchasedPart purchasedPart)
        {
            if (purchasedPart != null)
            {
                Id = purchasedPart.Id;
                Name = purchasedPart.Name;
                Value = purchasedPart.Value;
                UpsalePercent = purchasedPart.UpsalePercent;
                EstimateId = purchasedPart.EstimateId;
                VehicleId = purchasedPart.VehicleId;
                Estimate = purchasedPart.Estimate;
                Vehicle = purchasedPart.Vehicle;
            }

            Estimate ??= new Estimate();
            Vehicle ??= new Vehicle();
        }

        public PurchasedPart(PurchasedPartViewModel purchasedPartViewModel)
        {
            if (purchasedPartViewModel != null)
            {
                Id = purchasedPartViewModel.Id;
                Name = purchasedPartViewModel.Name;
                Value = purchasedPartViewModel.Value;
                Description = purchasedPartViewModel.Description;
                UpsalePercent = purchasedPartViewModel.UpsalePercent;
                VehicleId = purchasedPartViewModel.VehicleId;
                EstimateId = purchasedPartViewModel.EstimateId;
                Vehicle = purchasedPartViewModel.Vehicle;
                Estimate = purchasedPartViewModel.Estimate;
            }

            Estimate ??= new Estimate();
            Vehicle ??= new Vehicle();
        }

        [ForeignKey("Estimate")]
        public int EstimateId { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [Display(Name = "Profit Margin")]
        public int UpsalePercent { get; set; }

        public virtual Estimate Estimate { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}