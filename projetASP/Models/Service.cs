using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using projetASP.Tools;

namespace projetASP.Models
{
    public class Service
    {

        private int id;
        private string service;
        private static string request;
        private static MySqlConnection connection;
        private static MySqlCommand command;
        private static MySqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Nom_service { get => service; set => service = value; }

        public Service()
        {
        }

        public Service(string s)
        {
            service = s;
        }

        public Service(int i, string s) : this(s)
        {
            id = i;
        }

        public bool Save()
        {
            request = "INSERT INTO services (service) values (@service);";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@service", Nom_service));
            connection.Open();
            id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        public static List<Service> GetAllServices()
        {
            List<Service> list = new List<Service>();
            request = "SELECT * from services";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Service(reader.GetInt32(0), reader.GetString(1)));
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return list;
        }

        public static Service GetServiceById(int id)
        {
            Service service = null;
            request = "SELECT service FROM services WHERE service_id = @service_id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@service_id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                service = new Service()
                {
                    Id = id,
                    Nom_service = reader.GetString(0)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return service;
        }

        public bool Update()
        {
            request = "UPDATE services SET service=@service, service_id=@service_id WHERE service_id = @service_id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.AddWithValue("@service_id", id);
            command.Parameters.AddWithValue("@service", Nom_service);
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public bool Delete()
        {
            request = "DELETE FROM services WHERE service_id = @service_id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@service_id", id));
            command.Parameters.Add(new MySqlParameter("@service", Nom_service));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }


    }
}
