using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetASP.Services;
using projetASP.Models;

namespace projetASP.Controllers
{
    public class SalarieController : Controller
    {
        private ILogin _login;
        public SalarieController(ILogin login)
        {
            _login = login;
        }

        //Permet la redirection vers la page de login si on est pas connecté
        private IActionResult RedirectToLogin()
        {
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Salaries()
        {
            return View(Salarie.GetAllSalaries());
        }

        [Route("edit-salarie/{id?}")]
        public IActionResult SalarieEdit(int id)
        {
            if (_login.isLogged())
            {
                return View(Salarie.GetSalarieById(id));
            }
            else
            {
                return RedirectToLogin();
            }
        }

        public IActionResult Update(Salarie salarie)
        {
            if (salarie.Update())
            {
                return RedirectToAction("Salaries");
            }
            else
            {
                return RedirectToAction("SalarieEdit", "Salarie", new { error = true, message = "Erreur d'insertion" });
            }
        }

        [Route("delete-salarie/{id?}")]
        public IActionResult SalarieDelete(int id)
        {
            Salarie salarie = Salarie.GetSalarieById(id);
            if (salarie != null)
            {
                salarie.Delete();
            }
            return RedirectToAction("Salaries", "Salarie", new { message = "Erreur Suppression" });
        }

    }
}
