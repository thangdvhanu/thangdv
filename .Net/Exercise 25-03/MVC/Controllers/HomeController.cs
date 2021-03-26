using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<User> listUser = new List<User>();
        private List<Role> listRole = new List<Role>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            listUser.Add(new User() { UserId = 1, UserName = "admin", PassWord = "pass", RoleId = 1 });
            listUser.Add(new User() { UserId = 2, UserName = "member", PassWord = "pass", RoleId = 2 });
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                User userLoggingIn = ValidateUserInfo(user);
                if (userLoggingIn == null)
                {
                    return RedirectToAction("LoginForm", "Home");
                }
            }
            AddUserToSession(user);
            return View("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("RoleId");
            return View("Index", "Home");
        }
        private void AddUserToSession(User user)
        {
            HttpContext.Session.SetString("Username", user.UserName);
            HttpContext.Session.SetString("RoleId", user.RoleId.ToString());
        }
        private User ValidateUserInfo(User user)
        {
            var count = listUser.Count(x => x.UserName == user.UserName && x.PassWord == user.PassWord);
            if (count > 0) return user;
            return null;

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
