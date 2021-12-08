using Message.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.ViewModels
{
    public class ChatViewModel
    {
        public Chat Chat { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
