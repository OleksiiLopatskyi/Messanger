using Message.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Services
{
    interface IMessageService
    {
        Task Send(string message, ChatContext context);

    }
}
