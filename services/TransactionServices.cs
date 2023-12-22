using bank_api;

public class TransactionServices
{
    private UserServices userServices;
    private readonly ITransactionRepository Repository;
    private readonly HttpClient httpClient;
    public TransactionServices(ITransactionRepository repository)
    {
        Repository = repository;
        httpClient = new HttpClient();
        
    }

    public void CreateTransaction(TransactionDTO transaction)
    {
        User sender = userServices.GetUserById(transaction.senderID);
        User receiver = userServices.GetUserById(transaction.receiverID);

        userServices.ValidateTransaction(sender, transaction.value);
    }

//CONSTRUIR LOGICA PARA AUTORIZAÇÃO COM MOK
    // public bool autorizeTransaction(User sender, decimal value)
    // {
    //      var mock = "https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc";
    // }
}