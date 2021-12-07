using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public User UserMe { get; set; }
        public User UserWith { get; set; }
        public List<MessageModel> Messages { get; set; }
        public Chat()
        {
            Messages = new List<MessageModel>();
        }

    }
}
