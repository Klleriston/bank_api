using System.ComponentModel.DataAnnotations.Schema;

public class Transaction
{
    public int ID { get; private set; }
    public decimal Amount { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    [ForeignKey("SenderId")]
    public User? Sender { get; set; }
    
    [ForeignKey("ReceiverId")]
    public User? Receiver { get; set; }
    public DateTime timestamp;
}