using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo;

public class ChatHub : Hub
{
    private readonly ChatContext context;

    public ChatHub(ChatContext context)
    {
        this.context = context;
    }

    async Task<Chat> Send(Chat chat)
    {
        context.Chats.Add(chat);
        await context.SaveChangesAsync();
        return chat;
    }
    public async Task SendMessage(Chat chat)
    {
        // var chat = new Chat()
        // {
        //     User = user,
        //     Message = message
        // };

        var result = await Send(chat);
        await Clients.All.SendAsync("ReceiveMessage", result);
    }
}
