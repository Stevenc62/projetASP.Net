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

        [Route("edit-site/{id?}")]
        public IActionResult SiteEdit(int id)
        {
            if (_login.isLogged())
            {
                return View(Site.GetSiteById(id));
            }
            else
            {
                return RedirectToLogin();
            }
        }

        public IActionResult Update(Site site)
        {
            if (site.Update())
            {
                return RedirectToAction("Sites");
            }
            else
            {
                return RedirectToAction("SiteEdit", "Site", new { error = true, message = "Erreur d'insertion" });
            }
        }

        [Route("delete-site/{id?}")]
        public IActionResult SiteDelete(int id)
        {
            if (_login.isLogged())
            {
                Site site = Site.GetSiteById(id);
                if (site != null)
                {
                    site.Delete();
                }
                return RedirectToAction("Sites", "Site", new { message = "Erreur Suppression" });
            }
            else
            {
                return RedirectToLogin();
            }
        }
    }
}
