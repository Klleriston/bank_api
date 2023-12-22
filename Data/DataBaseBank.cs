using Microsoft.EntityFrameworkCore;

public class DatabaseBank : DbContext
{
    public DatabaseBank(DbContextOptions<DatabaseBank> options) : base(options)
    {
    }
    public DbSet<User> Users {get; set;}
    public DbSet<Transaction> Transactions {get; set;}

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.TransactionsSent)
            .WithOne(t => t.Sender)
            .HasForeignKey(t => t.SenderId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.TransactionsReceived)
            .WithOne(t => t.Receiver)
            .HasForeignKey(t => t.ReceiverId);
    }
}
