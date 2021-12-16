using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using projetASP.Tools;

namespace projetASP.Models
{
    public class Site
    {

        private string ville;
        private static string request;
        private static MySqlConnection connection;
        private static MySqlCommand command;
        private static MySqlDataReader reader;

        public string Ville { get => ville; set => ville = value; }

        public bool Save()
        {
            request = "INSERT INTO sites (ville) values (@ville);";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@ville", Ville));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public bool Update()
        {
            request = "UPDATE sites set ville=@ville where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@ville", Ville));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

    }

    

}
