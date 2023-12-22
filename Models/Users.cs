public enum TypeUser 
{
    Individual,
    LeaglEntity
}

public class User 
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public TypeUser Type { get; private set; }
    public decimal Balance { get; private set; }
    public User(int id, string name, TypeUser type, decimal balance)
    {
        Id = id;
        Name = name;
        Type = type;
        Balance = balance;
    }

    public void UpdateBalance(decimal newBalance)
    {
        Balance = newBalance;
    }
}
