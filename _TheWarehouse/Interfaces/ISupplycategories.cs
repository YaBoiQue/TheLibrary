namespace TheWarehouse.Interfaces
{
    public interface ISupplycategories : IRepository<Supplycategory>
    {
        Task<Supplycategory?> GetBySupply(ISpecification<Supply> objId);
    }
}
