

namespace TheWarehouse.Interfaces
{
    public interface IStocks : IRepository<Stock>
    {
        Task<IEnumerable<Stock>?> GetByUser(ISpecification<User> objId);
        Task<IEnumerable<Stock>?> GetByCode(ISpecification<Stockcode> objId);
        Task<IEnumerable<Stock>?> GetBySupply(ISpecification<Supply> objId);
    }
}
