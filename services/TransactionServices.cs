using System.Net;
using Newtonsoft.Json;
using bank_api;

public class TransactionServices
{
    private readonly UserServices userServices;
    private readonly ITransactionRepository Repository;
    private readonly HttpClient httpClient;


    public TransactionServices(ITransactionRepository repository, UserServices userServices)
    {
        Repository = repository;
        this.userServices = userServices;
        httpClient = new HttpClient();
    }


    public async Task<Transaction> CreateTransaction(TransactionDTO transaction)
    {
        User sender = userServices.GetUserById(transaction.senderID);
        User receiver = userServices.GetUserById(transaction.receiverID);

        userServices.ValidateTransaction(sender, transaction.value);

        bool isAuthorized = await AuthorizeTransaction(sender, transaction.value);

        if (!isAuthorized)
        {
            throw new Exception("Transação não autorizada");
        }

        Transaction newTransaction = new Transaction
        {
            Amount = transaction.value,
            Sender = sender,
            Receiver = receiver,
            timestamp = DateTime.Now
        };

        sender.UpdateBalance(sender.Balance - transaction.value);
        receiver.UpdateBalance(receiver.Balance + transaction.value);

        Repository.Update(newTransaction);
        userServices.AddU(sender);
        userServices.AddU(receiver);

        return newTransaction;

    }

    private async Task<bool> AuthorizeTransaction(User sender, decimal amount)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic responseJson = JsonConvert.DeserializeObject(content)!;
                string message = responseJson["message"];
                return "Autorizado".Equals(message, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na chamada da API de autorização: {ex.Message}");
            return false;
        }
    }


}
