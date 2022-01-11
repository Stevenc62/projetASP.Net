using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projetASP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using projetASP.Tools;

namespace projetASP.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Sites()
        {
            return View(Site.GetAllSites());
        }

        public IActionResult SiteEdit()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Salaries()
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
