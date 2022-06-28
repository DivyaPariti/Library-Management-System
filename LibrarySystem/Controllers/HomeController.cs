using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryManagementContext _context;

        public HomeController(ILogger<HomeController> logger, LibraryManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string uname, string psd)
        {

            if (uname != null && psd != null && uname.Equals("admin") && psd.Equals("admin"))
            {
                HttpContext.Session.SetString("username", uname);
                return RedirectToAction("Index", "BooksInfo");
            }
            else if (uname != null && psd != null && uname.Equals("John") && psd.Equals("password"))
            {
                HttpContext.Session.SetString("username", uname);
                return RedirectToAction("Index", "BooksInfoStu");
                //return View("Search");
            }
            else
            {
                ViewBag.error = "Invalid Credentials. Check again.";
                return View("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
