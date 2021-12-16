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

        private IActionResult RedirectToLogin()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
