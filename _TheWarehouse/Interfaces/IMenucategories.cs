namespace TheWarehouse.Interfaces
{
    public interface IMenucategories : IRepository<Menucategory>
    {
        Task<Menucategory?> GetByMenuItem(ISpecification<Menuitem> objId);
    }
}
