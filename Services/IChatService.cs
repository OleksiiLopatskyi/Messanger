using Message.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Services
{
    interface IChatService
    {
        Chat GetChat(ChatContext context);
        User GetSender(ChatContext context);
        User GetReceiver(ChatContext context);
        void Update(Chat chat,ChatContext context);
    }
}
