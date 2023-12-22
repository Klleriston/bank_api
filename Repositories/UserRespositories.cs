public interface IUserRepository
{
    User GetById(int userId);
    IEnumerable<User> GetAll();
    void Add(User user);
    void Update(User user);
    void Remove(User user);
}
public class UserRepository : IUserRepository
{
    private readonly DatabaseBank _context;

    public UserRepository(DatabaseBank context)
    {
        _context = context;
    }

    public User GetById(int userId)
    {
        return _context.Users.Find(userId);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}
