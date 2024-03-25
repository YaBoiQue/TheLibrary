using Ardalis.Specification;

namespace TheWarehouse.Interfaces.Views
{
    public interface IRepositoryView<TEntity> : IDisposable
    {
        Task<TEntity?> GetById(ISpecification<TEntity> objId);
        Task<IEnumerable<TEntity>?> ToList(ISpecification<TEntity> filterBy, ISpecification<TEntity> orderBy);
    }
}
