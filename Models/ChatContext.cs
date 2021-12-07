using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Models
{
    public class ChatContext:DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ChatContext(DbContextOptions<ChatContext>options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRole = "admin";
            string userRole = "user";
            string adminName = "Admin";
            string adminPassword = "12345";

            Role admin = new Role { Name = adminRole, Id = 1 };
            Role user = new Role { Name = userRole, Id = 2 };

            User adminAccount = new User { Id = 1,Username = adminName, Password = adminPassword, RoleId = 1};

            modelBuilder.Entity<Role>().HasData(new Role[] { admin, user });
            modelBuilder.Entity<User>().HasData(new User[] { adminAccount });
            base.OnModelCreating(modelBuilder);
        }
    }
}
