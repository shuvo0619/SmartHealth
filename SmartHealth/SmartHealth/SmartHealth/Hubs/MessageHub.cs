using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SmartHealth.Model.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace SmartHealth.Hubs
{
     //[HubName("MyChatHub")]
    public class MessageHub : Hub
    {
        public void Send(string name, string message)
        {
            //Clients.All.broadcastMessage(Username, message);
            Clients.All.addNewMessageToPage(name, message);
        }

        //public void SendMessage(Message message)
        //{
        //    IHubContext context = GlobalHost.ConnectionManager.GetHubContext("MyChatHub");
        //    context.Clients.All.pushNewMessage(message.MessageId, message.user.UserId, message.user.UserName, message.message, message.Date);
        //}

        //public void SendUserList(List<UserAuthentication> userList)
        //{
        //    IHubContext context = GlobalHost.ConnectionManager.GetHubContext("MyChatHub");
        //    context.Clients.All.pushUserList(userList);
        //}
    }
}