using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models.Linkers
{
    public class ServiceVehicleType
    {
        public ServiceVehicleType()
        {
            Name = "";
            DateCreated = DateTime.Now;

            Service = new Service();
            VehicleType = new VehicleType();
        }

        public ServiceVehicleType(int servicesId, int vehicleTypesId, string name)
        {
            ServicesId = servicesId;
            VehicleTypesId = vehicleTypesId;
            Name = name;
            DateCreated = DateTime.Now;

            Service = new Service();
            VehicleType = new VehicleType();
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Service")]
        public int ServicesId { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypesId { get; set; }

        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Service Service { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
