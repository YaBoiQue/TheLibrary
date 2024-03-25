namespace TheWarehouse.Interfaces
{
    public interface IStockcodes : IRepository<Stockcode>
    {
        Task<Stockcode?> GetByStock(ISpecification<Stock> objId);
    }
}
