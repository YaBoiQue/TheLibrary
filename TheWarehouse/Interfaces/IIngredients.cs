namespace TheWarehouse.Interfaces
{
    public interface IIngredients : IRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>?> GetByMenuItem(ISpecification<Menuitem> objId);
        Task<IEnumerable<Ingredient>?> GetBySupply(ISpecification<Supply> objId);
    }
}
