using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ApiCoreForSomee.Services;
using DAL.Models;

namespace ApiCoreForSomee.SignalRHub
{
    public class UserHub : Hub
    {
        
        private IApiControllerUse _apiController = new ApiControllerUse();

        static List<User> context = new List<User>();

        public void GetAll()
        {
            setContext();

            Clients.Caller.SendAsync("Refresh", context);
        }

        public void Post(User user)
        {
            _apiController.Create(user);

            setContext();

            Clients.All.SendAsync("Refresh", context);
        }


        public void setContext()
        {
            context = _apiController.GetAll().ToList();
        }
    }
}
