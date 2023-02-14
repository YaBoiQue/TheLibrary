//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RapidTireEstimates.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            this.VehicleParts = new HashSet<VehiclePart>();
        }
    
        public int Id { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int VehicleTypeId { get; set; }
        public int CustomerId { get; set; }
    
        public virtual VehicleType VehicleType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Estimate Estimate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehiclePart> VehicleParts { get; set; }
    }
}
