using Microsoft.EntityFrameworkCore;

public class DatabaseBank : DbContext
{
    public DatabaseBank(DbContextOptions<DatabaseBank> options) : base(options)
    {
    }
    public DbSet<User> Users {get; set;}
}
