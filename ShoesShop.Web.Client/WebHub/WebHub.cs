using Microsoft.AspNetCore.SignalR;

namespace ShoesShop.Web.Client.WebHub;

public class WebHub : Hub
{
    public async Task ReceiveMessage(string type, string message)
    {
        if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(message))
        {
            await Clients.All.SendAsync("ReceiveMessage", type, message);
        }
    }
}