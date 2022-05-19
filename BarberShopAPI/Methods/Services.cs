
using System.Data;
using System.Data.SqlClient;
using BarberShopAPI.Settings;

namespace BarberShopAPI.Data
{
    public class Services
    {
        public static DataTable GetServices()
        {
            DataTable services = new DataTable();  
            SqlConnection conn = new(Settings.Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Settings.Database.Queries.Services.Get, conn);
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows) {
                    services.Load(reader);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
           
            return services;
        }

        public static string AddService(string Name, string Price)
        {
            string result = null;

            SqlConnection conn = new(Settings.Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Settings.Database.Queries.Services.Add, conn);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Price", Price);
                int rows = command.ExecuteNonQuery();
                if(rows > 0)
                {
                    result = "Success";

                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public static string UpdateName(int Id, string Name)
        {
            string response = string.Empty;
            SqlConnection conn = new(Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Database.Queries.Services.UpdateName, conn);
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Name", Name);
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "Success" : "Fail";

            }
            catch(SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
            return response;

        }

        public static string UpdatePrice(int Id, int Price)
        {
            string response = string.Empty;
            SqlConnection conn = new(Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Database.Queries.Services.UpdatePrice, conn);
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Price", Price);
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "Success" : "Fail";

            }
            catch (SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
            return response;
        }

        public static string DeleteService(int Id)
        {
            string response = string.Empty;
            SqlConnection conn = new(Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Database.Queries.Services.Delete, conn);
                command.Parameters.AddWithValue("@Id", Id);
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "Success" : "Fail";

            }
            catch (SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
            return response;
        }


        
    }
}
