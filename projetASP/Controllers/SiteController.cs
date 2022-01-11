using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetASP.Services;
using projetASP.Models;

namespace projetASP.Controllers
{
    public class SiteController : Controller
    {
        private ILogin _login;
        public SiteController(ILogin login)
        {
            _login = login;
        }

        //Permet la redirection vers la page de login si on est pas connecté
        private IActionResult RedirectToLogin()
        {
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Sites()
        {
            return View(Site.GetAllSites());
        }

        public IActionResult SiteEdit(int id)
        {
            if (_login.isLogged())
            {
                Site site = null;
                site = Site.GetSiteById((int)id);
                return View(site);
            }
            else
            {
                return RedirectToLogin();
            }
        }
    }
}
