using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServiceVehicleType
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Service")]
        public int ServicesId { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypesId { get; set; }

        public string Name { get; set; }

        public virtual Service Service { get; set; }
        public virtual VehicleType VehicleType { get; set; }

        public ServiceVehicleType(int servicesId, int vehicleTypesId)
        {
            ServicesId = servicesId;
            VehicleTypesId = vehicleTypesId;
        }
    }
}
