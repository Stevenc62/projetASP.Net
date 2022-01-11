using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetASP.Models;

namespace projetASP.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Sites()
        {
            return View(Site.GetAllSites());
        }

        public IActionResult SiteEdit(int id)
        {
            return View(Site.GetSiteById((int)id));
        }
    }
}
