using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEstimates.Models;

namespace EasyEstimates.Interfaces
{
    public interface ISpecRepository : IDisposable
    {
        public Task<Spec> GetSpec(Specification<Spec> byIdSpec);
        public Task<ICollection<Spec>> GetSpecs();
        public Task<ICollection<Spec>> GetSpecsByServiceId(Specification<Spec> byServiceIdSpec);
        public Task<Spec> AddSpec(Spec spec);
        public Task RemoveSpec(Spec spec);
    }
}
