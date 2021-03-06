﻿using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AppWebClient.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string date)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, date);
        }
    }
}
