using Message.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ChatContext _db;
        public HomeController(ILogger<HomeController> logger,ChatContext context)
        {
            _logger = logger;
            _db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _db.Users.FirstOrDefault(i=>i.Username==User.Identity.Name); 
            return View(_db.Users.Where(i=>i.Id!=user.Id));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
