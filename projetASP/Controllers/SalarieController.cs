using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetASP.Controllers
{
    public class SalarieController : Controller
    {
        public IActionResult Salaries()
        {
            return View();
        }
    }
}
