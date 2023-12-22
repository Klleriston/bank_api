public class UserServices
{
    private readonly IUserRepository Repository;
    public UserServices(IUserRepository repository)
    {
        Repository = repository;
    }

    public void ValidateTransaction(User sender, decimal amount)
    {
        if (sender.Type == TypeUser.LegalEntity)
        {
            throw new Exception("User type is unable to make transactions");
        }
        if (sender.Balance.CompareTo(amount) < 0)
        {
            throw new Exception("Not allowed");
        }
    }
    public User GetUserById(int id)
    {
        User user = Repository.GetById(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public void AddU(User user)
    {
        Repository.Update(user);
    }
}