using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
