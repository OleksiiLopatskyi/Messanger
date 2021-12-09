using Message.Models;
using Message.ViewModels;
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
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var user = await _db.Users.FirstOrDefaultAsync(i => i.Username == User.Identity.Name);
            ChatViewModel model = new ChatViewModel
            {
                Users = _db.Users.Where(i => i.Id != user.Id),
                Chat=null
            };
            return View(model);
        }
       // [Route("[controller]/[action]/{name}")]
        public async Task<IActionResult> ChatName(string name)
        {
            if (name == null)
            {
                return View(_db.Chats.Include(i => i.Messages).FirstOrDefault(i => i.Id == Chat.Id));
            }
            UserMe = await _db.Users.FirstOrDefaultAsync(i => i.Username == User.Identity.Name);
            UserTo = await _db.Users.FirstOrDefaultAsync(i => i.Username == name);
            Chat =  _db.Chats.Include(i=>i.Messages).FirstOrDefault(i => i.UserWith == UserTo && i.UserMe == UserMe || i.UserMe == UserTo && i.UserWith == UserMe);
            ChatViewModel model = new ChatViewModel
            {
                Users = _db.Users.Where(i => i.Id != UserMe.Id),
                Chat = Chat
            };
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
                return View("ChatBox",model);
            }
           
            return PartialView("ChatBox",model.Chat);
        }
     
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
            return PartialView("Messages",Chat);
        }

    }
}
