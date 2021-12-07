using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public User From { get; set; }
        public User To { get; set; }
        public string Text { get; set; }
    }
}
