namespace TheWarehouse.Interfaces
{
    public interface IMenuitems : IRepository<Menuitem>
    {
        Task<Menuitem?> GetByTransactionItem(ISpecification<Transactionitem> objId);
        Task<Menuitem?> GetByIngredient(ISpecification<Ingredient> objId); 
        Task<IEnumerable<Menuitem>?> GetByCategory(ISpecification<Menucategory> objId);
    }
}
