using Microsoft.AspNetCore.SignalR;

namespace ChatExpress;

public class ChatHub : Hub
{
    public async Task EnviarMensaje(string usuario, string mensaje)
    {
        await Clients.All.SendAsync("RecibirMensaje", usuario, mensaje);
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("RecibirMensaje", "Sistema", $"{Context.ConnectionId[..6]} se conectó");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.All.SendAsync("RecibirMensaje", "Sistema", $"{Context.ConnectionId[..6]} se desconectó");
        await base.OnDisconnectedAsync(exception);
    }
}
