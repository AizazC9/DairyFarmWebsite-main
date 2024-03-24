using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DairyFarm.Controllers

{
    public class LoginController : Controller
    {
          [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

   [HttpPost]
public IActionResult Login(string username, string password)
{
    if (username == "admin" && password == "admin")
    {
        // HttpContext.Session.SetString("IsLoggedIn", "true");
        return RedirectToAction("Index", "Cattle");
    }
    else
    {
        ViewBag.Error = "Invalid username or password.";
        return View();
    }
}

// public IActionResult Logout()
// {
//     var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");
//     if (string.IsNullOrEmpty(isLoggedIn) || isLoggedIn != "true")
//     {
//         return RedirectToAction("Login", "Login");
//     }
//     HttpContext.Session.Clear();

//     return RedirectToAction("Login", "Login");
// }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}