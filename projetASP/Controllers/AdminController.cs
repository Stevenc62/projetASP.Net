using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetASP.Services;
using projetASP.Models;

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


        //Securité afin d'acceder au formulaire seulement en etant connecter et donc en etant administrateurs
        public IActionResult FormSite(string message, bool error = false)
        {
            if (_login.isLogged())
            {
                ViewBag.Error = error;
                ViewBag.Message = message;
                return View();
            }
            else
            {
                return RedirectToLogin();
            }
        }

        //Envoi du formulaire en BDD
        public IActionResult SubmitFormSite([Bind("Ville")] Site site )
        {
            if (site.Save())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("FormSite", "Admin", new { error = true, message = "Erreur d'insertion" });
            }
        }

        public IActionResult FormService(string message, bool error = false)
        {
            if (_login.isLogged())
            {
                ViewBag.Error = error;
                ViewBag.Message = message;
                return View();
            }
            else
            {
                return RedirectToLogin();
            }
        }

        public IActionResult SubmitFormService([Bind("Nom_service")] Service service)
        {
            if (service.Save())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("FormService", "Admin", new { error = true, message = "Erreur d'insertion" });
            }
        }

        public IActionResult FormSalarie(string message, bool error = false)
        {
            if (_login.isLogged())
            {
                ViewBag.Error = error;
                ViewBag.Message = message;
                return View();
            }
            else
            {
                return RedirectToLogin();
            }
        }

        public IActionResult SubmitFormSalarie([Bind("Nom, Prenom, Fix, Portable, Mail, Service_id, Site_id")] Salarie salarie)
        {
            if (salarie.Save())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("FormSalarie", "Admin", new { error = true, message = "Erreur d'insertion" });
            }
        }

        //Permet la redirection vers la page de login si on est pas connecté
        private IActionResult RedirectToLogin()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
