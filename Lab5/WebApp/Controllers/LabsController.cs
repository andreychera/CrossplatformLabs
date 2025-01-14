using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class LabsController : Controller
    {
        private readonly PracticalPrograms _programs = new PracticalPrograms();

        public IActionResult Program1() => View();

        [HttpPost]
        public IActionResult Program1(string input)
        {
            ViewBag.Result = _programs.Program1(input);
            return View();
        }

        public IActionResult Program2() => View();

        [HttpPost]
        public IActionResult Program2(int number)
        {
            ViewBag.Result = _programs.Program2(number);
            return View();
        }

        public IActionResult Program3() => View();

        [HttpPost]
        public IActionResult Program3(string text)
        {
            ViewBag.Result = _programs.Program3(text);
            return View();
        }
    }
}