using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ProductShopMVC.Services.Models.Clients;
using ProductShopMVC.Services.Models.Clients.DbModels;


namespace ProductShopMVC.Services.Repositories.Clients
{
    public static class ClientsRepository
    {

        private static String connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=Usama667;Database=ProductDirect;";

        public static List<DbClient> GetAllClients()
        {
            List<DbClient> result = new List<DbClient>();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using (var cmd = new NpgsqlCommand("SELECT * FROM clients", connection))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    result.Add(setBdProduct(reader));
                }
            return result;
        }
        public static void DelClient(string clientId)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            using (var cmd = new NpgsqlCommand("DELETE FROM clients " +
                                              "WHERE clientId = @id", connection))
            {
                cmd.Parameters.AddWithValue("id", clientId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void AddClient(DbClient newClient)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            using (var cmd = new NpgsqlCommand("INSERT INTO clients (clientId, clientLastName, clientFirstName, clientMiddleName, clientBirthDay, clientPhoneNumber, clientEmail) " +
                                               "VALUES(@id, @lastName, @firstName, @middleName, @birthDay, @phoneNumber, @email)", connection))
            {
                cmd.Parameters.AddWithValue("id", newClient.DbClientId);
                cmd.Parameters.AddWithValue("lastName", newClient.DbClientLastName);
                cmd.Parameters.AddWithValue("firstName", newClient.DbClientFirstName);
                cmd.Parameters.AddWithValue("middleName", newClient.DbClientMiddleName);
                cmd.Parameters.AddWithValue("birthDay", newClient.DbClientBirthday);
                cmd.Parameters.AddWithValue("phoneNumber", newClient.DbClientPhoneNumber);
                cmd.Parameters.AddWithValue("email", newClient.DbClientEmail);
                cmd.ExecuteNonQuery();

            }
        }
        public static void EditClient(DbClient changedClient)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            using (var cmd = new NpgsqlCommand("UPDATE clients " +
                                               "SET clientLastName = @lastName, clientFirstName = @firstName, clientMiddleName = @middleName, " +
                                               "clientBirthDay = @birthDay, clientPhoneNumber = @phoneNumber, clientEmail = @email " +
                                               "WHERE clientId = @id", connection))
            {
                cmd.Parameters.AddWithValue("lastName", changedClient.DbClientLastName);
                cmd.Parameters.AddWithValue("firstName", changedClient.DbClientFirstName);
                cmd.Parameters.AddWithValue("middleName", changedClient.DbClientMiddleName);
                cmd.Parameters.AddWithValue("birthDay", changedClient.DbClientBirthday);
                cmd.Parameters.AddWithValue("phoneNumber", changedClient.DbClientPhoneNumber);
                cmd.Parameters.AddWithValue("email", changedClient.DbClientEmail);
                cmd.Parameters.AddWithValue("id", changedClient.DbClientId);
                cmd.ExecuteNonQuery();
            }
        }

        public static DbClient GetClientById(string id)
        {
            DbClient result = new DbClient();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            using (var cmd = new NpgsqlCommand("SELECT * FROM clients " +
                                               "WHERE clientId = @id ", connection))
            {
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        result = setBdProduct(reader);
                    }
            }
            return result;
        }
        public static DbClient GetClientByEmail(string email)
        {
            DbClient result = new DbClient();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            using (var cmd = new NpgsqlCommand("SELECT * FROM clients " +
                                               "WHERE clientEmail = @email ", connection))
            {
                cmd.Parameters.AddWithValue("email", email);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        result = setBdProduct(reader);
                    }
            }
            return result;
        }

        public static List<DbClient> SearchClientsByEmail(string email)
        {
            List<DbClient> result = new List<DbClient>();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using (var cmd = new NpgsqlCommand("SELECT * FROM clients " +
                                               "WHERE clientEmail ILIKE @email", connection))
            {
                cmd.Parameters.AddWithValue("email", email);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        result.Add(setBdProduct(reader));
                    }
            }
            return result;
        }

        public static List<DbClient> GetClientsByLastName(string lastName)
        {
            List<DbClient> result = new List<DbClient>();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using (var cmd = new NpgsqlCommand("SELECT * FROM clients " +
                                               "WHERE clientLastName ILIKE @lastName", connection))
            {
                cmd.Parameters.AddWithValue("lastName", lastName);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        result.Add(setBdProduct(reader));
                    }
            }
            return result;
        }

        private static DbClient setBdProduct(NpgsqlDataReader reader)
        {
            return new DbClient(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6));
        }
    }
}
