using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace TheWarehouse.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        void Create(TEntity obj);
        void Save(TEntity obj);
        void Delete(TEntity obj);
        object GetById(object objId);
        IQueryable<TEntity> ToList();
    }
}
