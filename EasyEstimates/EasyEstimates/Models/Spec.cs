using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEstimates.Models
{
    public class Spec
    {
        public int Id { get; set; }
        
        //Service
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        //Vehicle Type
        public string VehicleType { get; set; }

        //Tire Size
        public string TireSize { get; set; }
    }
}
