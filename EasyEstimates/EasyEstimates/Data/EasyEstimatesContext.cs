using EasyEstimates.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEstimates.Data
{
    public class EasyEstimatesContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Spec> Specs { get; set; }
    }
}
