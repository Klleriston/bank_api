namespace bank_api;

public record class TransactionDTO(decimal value, int senderID, int receiverID)
{

}
