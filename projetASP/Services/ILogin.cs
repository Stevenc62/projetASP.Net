using System;
using projetASP.Models;

namespace projetASP.Services
{
    public interface ILogin
    {
        bool isLogged();
        string GetLogin();
        bool LogIn(string login, string password);
    }
}
