using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Utility.MVC.Models;

namespace Utility.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var aux = new List<Levels>()
            {
                new Levels()
                {
                    MenuLevel = 1,
                    Items = new List<string>()  { "Test", "Test" },
                    Filters  = new List<string>()  { "Test","Test","Test" },
                },
                new Levels()
                {
                    MenuLevel = 2,
                    Items = new List<string>()  { "Test", "Test" },
                    Filters  = new List<string>()  { "Test","Test","Test" },
                },
                new Levels()
                {
                    MenuLevel = 3,
                    Items = new List<string>()  { "Test", "Test" },
                    Filters  = new List<string>()  { "Test","Test","Test" },
                },
            };
            return View(aux);
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

    public class Levels
    {
        public int MenuLevel { get; set; }
        public List<string> Items { get; internal set; }
        public List<string> Filters { get; internal set; }
    }
}
