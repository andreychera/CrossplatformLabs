using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User model)
    {
        if (ModelState.IsValid)
        {
            TempData["Success"] = "User registered successfully!";
            return RedirectToAction("Login");
        }
        return View(model);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == "test" && password == "Password@123")
        {
            TempData["IsAuthenticated"] = true;
            return RedirectToAction("Profile");
        }
        ModelState.AddModelError("", "Invalid username or password.");
        return View();
    }

    public IActionResult Profile()
    {
        if (TempData["IsAuthenticated"] == null)
        {
            return RedirectToAction("Login");
        }
        return View();
    }
    }
}