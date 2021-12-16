using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetASP.Services;

namespace projetASP.Controllers
{
    public class AdminController : Controller
    {
        private ILogin _login;
        public AdminController(ILogin login)
        {
            _login = login;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
