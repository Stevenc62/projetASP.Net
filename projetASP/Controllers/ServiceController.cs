using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetASP.Services;
using projetASP.Models;

namespace projetASP.Controllers
{
    public class ServiceController : Controller
    {

        private ILogin _login;
        public ServiceController(ILogin login)
        {
            _login = login;
        }

        //Permet la redirection vers la page de login si on est pas connecté
        private IActionResult RedirectToLogin()
        {
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Services()
        {
            return View(Service.GetAllServices());
        }

        [Route("edit-service/{id?}")]
        public IActionResult ServiceEdit(int id)
        {
            if (_login.isLogged())
            {
                return View(Service.GetServiceById(id));
            }
            else
            {
                return RedirectToLogin();
            }
        }

        public IActionResult Update(Service service)
        {
            if (service.Update())
            {
                return RedirectToAction("Services");
            }
            else
            {
                return RedirectToAction("ServiceEdit", "Service", new { error = true, message = "Erreur d'insertion" });
            }
        }

        [Route("delete-service/{id?}")]
        public IActionResult ServiceDelete(int id)
        {
            Service service = Service.GetServiceById(id);
            if (service != null)
            {
                service.Delete();
            }
            return RedirectToAction("Services", "Service", new { message = "Erreur Suppression" });
        }

     }
}
