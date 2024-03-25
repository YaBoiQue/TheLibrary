namespace TheWarehouse.Interfaces
{
    public interface ITransactioncodes : IRepository<Transactioncode>
    {
        Task<Transactioncode?> GetByTransaction(ISpecification<Transaction> objId);
    }
}
