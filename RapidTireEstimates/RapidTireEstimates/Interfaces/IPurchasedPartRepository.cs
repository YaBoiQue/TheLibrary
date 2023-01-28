using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;
using Xamarin.Forms;

namespace RapidTireEstimates.Interfaces
{
    public interface IPurchasedPartRepository : IDisposable
    {
        public Task<List<PurchasedPart>> GetAll(
            ISpecification<PurchasedPart> filterBySpec,
            ISpecification<PurchasedPart> orderBySpec
            );
        public Task<List<PurchasedPart>> GetByEstimateId(
            ISpecification<PurchasedPart> byEstimateIdSpec,
            ISpecification<PurchasedPart> filterBySpec,
            ISpecification<PurchasedPart> orderBySpec
            );
        public Task<List<PurchasedPart>> GetByVehicleId(
            ISpecification<PurchasedPart> byVehicleIdSpec,
            ISpecification<PurchasedPart> filterBySpec,
            ISpecification<PurchasedPart> orderBySpec
            );
        public Task<PurchasedPart> GetById(
            ISpecification<PurchasedPart> byIdSpec
            );
        public Task<PurchasedPart> Insert(
            PurchasedPartViewModel purchasedPartViewModel
            );
        public Task<PurchasedPart> Update(
            ISpecification<PurchasedPart> byIdSpec,
            PurchasedPartViewModel purchasedPartViewModel
            );
        public Task<PurchasedPart> Delete(
            ISpecification<PurchasedPart> byIdSpec
            );
    }
}
