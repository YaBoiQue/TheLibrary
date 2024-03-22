namespace TheWarehouse.Interfaces
{
    public interface ITransactions : IRepository<Transaction>
    {
        Task<Transaction?> GetByTransactionItem(ISpecification<Transactionitem> objId);
        Task<IEnumerable<Transaction>?> GetByUser(ISpecification<User> objId);
        Task<IEnumerable<Transaction>?> GetByType(ISpecification<Transactioncode> objId);
    }
}
