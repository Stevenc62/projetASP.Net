using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetASP.Tools
{
    public class Db
    {
        public Db()
        {
        }

        private static string connectionString = "Server=127.0.0.1;DataBase=projet_asp;UserId=root;password=";
        public static MySqlConnection Connection { get => new MySqlConnection(connectionString); }
    }
}
