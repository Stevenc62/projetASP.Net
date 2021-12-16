﻿using Microsoft.AspNetCore.Mvc;
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

        //Permet la redirection vers la page de login si on est pas connecté
        private IActionResult RedirectToLogin()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
