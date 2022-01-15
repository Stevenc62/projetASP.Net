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
        private int id;
        private string ville;
        private static string request;
        private static MySqlConnection connection;
        private static MySqlCommand command;
        private static MySqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Ville { get => ville; set => ville = value; }


        public Site()
        {
        }

        public Site(string v)
        {
            ville = v;
        }

        public Site(int i, string v) : this(v)
        {
            id = i;
        }

        public bool Save()
        {
            request = "INSERT INTO sites (ville) values (@ville);";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@ville", Ville));
            connection.Open();
            id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        public static List<Site> GetAllSites()
        {
            List<Site> list = new List<Site>();
            request = "SELECT * from sites";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Site(reader.GetInt32(0), reader.GetString(1)));
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return list;
        }

        
        public static Site GetSiteById(int id)
        {
            Site site = null;
            request = "SELECT ville FROM sites WHERE site_id = @site_id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@site_id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                site = new Site()
                {
                    Id = id,
                    Ville = reader.GetString(0)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return site;
        }

        public bool Update()
        {
            request = "UPDATE sites SET ville=@ville, site_id=@site_id WHERE site_id = @site_id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.AddWithValue("@site_id", id);
            command.Parameters.AddWithValue("@ville", Ville);
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public bool Delete()
        {
            request = "DELETE FROM sites WHERE site_id = @site_id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@site_id", id));
            command.Parameters.Add(new MySqlParameter("@ville", Ville));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

    }



}
