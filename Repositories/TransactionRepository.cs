public interface ITransactionRepository
{
    void Add(Transaction transaction);
    void Update(Transaction transaction);
    Transaction GetById(int transactionId);
    IEnumerable<Transaction> GetAll();
}

public class TransactionRepository : ITransactionRepository
{
    private readonly DatabaseBank _context;

    public TransactionRepository(DatabaseBank context)
    {
        _context = context;
    }

    public void Add(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public void Update(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        _context.SaveChanges();
    }

    public Transaction GetById(int transactionId)
    {
        return _context.Transactions.Find(transactionId);
    }

    public IEnumerable<Transaction> GetAll()
    {
        return _context.Transactions.ToList();
    }
}