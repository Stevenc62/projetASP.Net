using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetASP.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projetASP.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login;

        public LoginController(ILogin login)
        {
            _login = login;
        }
        // GET: /<controller>/
        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        public IActionResult SubmitLogin(string login, string password)
        {
            if(_login.LogIn(login, password))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Login", new { message = "Erreur de connexion" });
            }
        }
    }
}
