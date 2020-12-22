using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreForSomee.SignalRHub
{
    public class ChatHub : Hub
    {
        static List<string> context = new List<string>();

        public void GetAll()
        {
            Clients.Caller.SendAsync("Refresh", context);
        }

        public void Post(string msg)
        {
            context.Add(msg);
            Clients.All.SendAsync("Refresh", context);
        }


        public void Reset()
        {
            context.Clear();
            Clients.All.SendAsync("Admin", context);
        }

    }

}