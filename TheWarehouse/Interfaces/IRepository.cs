using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace TheWarehouse.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task<TEntity?> Create(TEntity obj);
        Task<TEntity?> Save(ISpecification<TEntity> objId, TEntity obj );
        Task<TEntity?> Delete(ISpecification<TEntity> objId);
        Task<TEntity?> GetById(ISpecification<TEntity> objId);
        Task<IEnumerable<TEntity>?> ToList(ISpecification<TEntity> filterBy, ISpecification<TEntity> orderBy);
    }
}
