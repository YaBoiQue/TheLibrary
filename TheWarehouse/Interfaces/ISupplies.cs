namespace TheWarehouse.Interfaces
{
    public interface ISupplies : IRepository<Supply>
    {
        Task<Supply?> GetByStock(ISpecification<Stock> objId);
        Task<Supply?> GetByIngredient(ISpecification<Ingredient> objId);
        Task<IEnumerable<Supply>?> GetByCategory(ISpecification<Supplycategory> objId);
        Task<IEnumerable<Supply>?> GetBySupplier(ISpecification<Supplier> objId);
    }
}
