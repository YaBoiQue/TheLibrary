namespace TheWarehouse.Interfaces
{
    public interface ISuppliers : IRepository<Supplier>
    {
        Task<Supplier?> GetBySupply(ISpecification<Supply> objId);
    }
}
