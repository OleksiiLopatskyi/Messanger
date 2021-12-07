using Message.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Controllers
{
    public class ChatController : Controller
    {
        private ChatContext _db;
        private static Chat Chat;
        private static User UserMe,UserTo;
        public ChatController(ChatContext context)
        {
            _db = context;

        }
        [Route("[controller]/[action]/{name}")]
        public async Task<IActionResult> Index(string name)
            {
            UserMe = await _db.Users.FirstOrDefaultAsync(i => i.Username == User.Identity.Name);
            UserTo = await _db.Users.FirstOrDefaultAsync(i => i.Username == name);
            Chat = await _db.Chats.FirstOrDefaultAsync(i => i.UserWith == UserTo && i.UserMe == UserMe || i.UserMe == UserTo && i.UserWith == UserMe);
            if (Chat == null)
            {
                Chat chat = new Chat()
                {
                    UserMe = await _db.Users.FirstOrDefaultAsync(i => i.Username == User.Identity.Name),
                    UserWith = await _db.Users.FirstOrDefaultAsync(i => i.Username == name)
                };
                Chat = chat;
                await _db.Chats.AddAsync(chat);
                _db.SaveChanges();
                return View(chat);
            }

            return View(_db.Chats.Include(i=>i.Messages).FirstOrDefault(i => i.Id == Chat.Id));
        }
        [HttpPost]
        public  IActionResult SendMessage(string message)
        {
            MessageModel newMessage = new MessageModel
            {
                From = UserMe,
                To = UserTo,
                ChatId = Chat.Id,
                Text = message,
                Date = DateTime.Now.ToString("hh:mm")
            };
            Chat.Messages.Add(newMessage);
            _db.Update(Chat);
            _db.SaveChanges();
            return RedirectToAction("Index",new {name=UserTo.Username});
        }

    }
}
