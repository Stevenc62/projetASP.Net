using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using projetASP.Tools;

namespace projetASP.Models
{
    public class Salarie
    {

        private int id;
        private string nom;
        private string prenom;
        private string fix;
        private string portable;
        private string mail;
        private int service_id;
        private int site_id;
        private static string request;
        private static MySqlConnection connection;
        private static MySqlCommand command;
        private static MySqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Fix { get => fix; set => fix = value; }
        public string Portable { get => portable; set => portable = value; }
        public string Mail { get => mail; set => mail = value; }
        public int Service_id { get => service_id; set => service_id = value; }
        public int Site_id { get => site_id; set => site_id = value; }

        public Salarie()
        {
        }

        public Salarie(string n, string pr, string f, string p, string m, int se, int si)
        {
            nom = n;
            prenom = pr;
            fix = f;
            portable = p;
            mail = m;
            service_id = se;
            site_id = si;
        }

        public Salarie(int i, string n, string pr, string f, string p, string m, int se, int si) : this(n, pr, f, p, m, se, si)
        {
            id = i;
        }

        public bool Save()
        {
            request = "INSERT INTO salaries (nom, prenom, fix, portable, mail, service_id, site_id) values(@nom, @prenom, @fix, @portable, @mail, @service_id, @site_id);";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@nom", Nom));
            command.Parameters.Add(new MySqlParameter("@prenom", Prenom));
            command.Parameters.Add(new MySqlParameter("@fix", Fix));
            command.Parameters.Add(new MySqlParameter("@portable", Portable));
            command.Parameters.Add(new MySqlParameter("@mail", Mail));
            command.Parameters.Add(new MySqlParameter("@service_id", Service_id));
            command.Parameters.Add(new MySqlParameter("@site_id", Site_id));
            connection.Open();
            id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        public static List<Salarie> GetAllSalaries()
        {
            List<Salarie> list = new List<Salarie>();
            request = "SELECT * from salaries";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Salarie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7)));
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return list;
        }

        public static Salarie GetSalarieById(int id)
        {
            Salarie salarie = null;
            request = "SELECT nom, prenom, fix, portable, mail, service_id, site_id FROM salaries WHERE salarie_id = @salarie_id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@salarie_id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                salarie = new Salarie()
                {
                    Id = id,
                    Nom = reader.GetString(0),
                    Prenom = reader.GetString(1),
                    Fix = reader.GetString(2),
                    Portable = reader.GetString(3),
                    Mail = reader.GetString(4),
                    Service_id = reader.GetInt32(5),
                    Site_id = reader.GetInt32(6)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return salarie;
        }

        public bool Update()
        {
            request = "UPDATE salaries SET salarie_id=@salarie_id, nom=@nom, prenom=@prenom, fix=@fix, portable=@portable, mail=@mail, service_id=@service_id, site_id=@site_id  WHERE salarie_id = @salarie_id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.AddWithValue("@salarie_id", id);
            command.Parameters.AddWithValue("@nom", Nom);
            command.Parameters.AddWithValue("@prenom", Prenom);
            command.Parameters.AddWithValue("@fix", Fix);
            command.Parameters.AddWithValue("@portable", Portable);
            command.Parameters.AddWithValue("@mail", Mail);
            command.Parameters.AddWithValue("@service_id", Service_id);
            command.Parameters.AddWithValue("@site_id", Site_id);
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public bool Delete()
        {
            request = "DELETE FROM salaries WHERE salarie_id = @salarie_id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@salarie_id", id));
            command.Parameters.Add(new MySqlParameter("@nom", Nom));
            command.Parameters.Add(new MySqlParameter("@prenom", Prenom));
            command.Parameters.Add(new MySqlParameter("@fix", Fix));
            command.Parameters.Add(new MySqlParameter("@portable", Portable));
            command.Parameters.Add(new MySqlParameter("@mail", Mail));
            command.Parameters.Add(new MySqlParameter("@service_id", Service_id));
            command.Parameters.Add(new MySqlParameter("@site_id", Site_id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

    }
}
