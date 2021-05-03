using System;
using System.Web;
using ChatApp.Models;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class ChatHub : Hub
    {
        private ChatDataEntities db = new ChatDataEntities();
        public void Send(string name, string message)
        {
            var chat = new Table { Message = message, UserName = name };
            db.Table.Add(chat);
            db.SaveChanges();
            Clients.All.addNewMessageToPage(chat);
        }
    }
}