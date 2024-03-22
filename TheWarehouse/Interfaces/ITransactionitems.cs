namespace TheWarehouse.Interfaces
{
    public interface ITransactionitems : IRepository<Transactionitem>
    {
        Task<IEnumerable<Transactionitem>?> GetByTransaction(ISpecification<Transaction> objId);
        Task<IEnumerable<Transactionitem>?> GetByMenuItem(ISpecification<Menuitem> objId);
    }
}
