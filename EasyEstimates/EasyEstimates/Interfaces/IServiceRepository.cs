using Ardalis.Specification;
using EasyEstimates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace EasyEstimates.IRepository
{
    public interface IServiceRepository : IDisposable
    {
        public Task<Service> GetService(Specification<Service> byIdSpec);
        public Task<ICollection<Service>> GetServices();
        public Task<ICollection<Service>> GetServicesBySpecId(Specification<Service> bySpecIdSpec);
        public Task<Service> AddService(Service service);
        public Task RemoveService(Service service);
    }
}
