using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using bank_api;

public class NotificationService
{
    private async Task<bool> NotificationOK()
    {
        HttpResponseMessage response = await HttpClient("https://run.mocky.io/v3/54dc2cf1-3add-45b5-b5a9-6bf7e7f1f4a6");

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        return false;
    }

    public async void SendNotification(User user, string msg)
    {
        string email = user.Email;
        NotificationDTO notificationRequest = new NotificationDTO(email, msg);

        bool notificationOK = await NotificationOK();

        if (!notificationOK)
        {
            throw new Exception("Serviço indisponível");
        }
    }

    private async Task<HttpResponseMessage> HttpClient(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            return await client.GetAsync(url);
        }
    }
}
