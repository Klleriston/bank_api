public class User 
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public TypeUser Type { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public decimal Balance { get; private set; }

      public ICollection<Transaction> TransactionsSent { get; set; } = new List<Transaction>();
    public ICollection<Transaction> TransactionsReceived { get; set; } = new List<Transaction>();
    
    public User(int id, string firstName, string lastName, TypeUser type,string document, string email, string password, decimal balance)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Type = type;
        Document = document;
        Email = email;
        Password = password;
        Balance = balance;
    }

    public void UpdateBalance(decimal newBalance)
    {
        Balance = newBalance;
    }
}
