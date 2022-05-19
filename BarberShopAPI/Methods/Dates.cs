using System.Data;
using System.Data.SqlClient;
using BarberShopAPI.Settings;

namespace BarberShopAPI.Methods
{
    public class Dates
    {
        public static DataTable GetDates()
        {
            DataTable dates = new();
            SqlConnection conn = new(Database.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand command = new(Database.Queries.Dates.Get, conn);
                SqlDataReader reader = command.ExecuteReader();
                
                if(reader.HasRows)
                {
                    dates.Load(reader);
                }
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return dates;
        }
        public static DataTable GetDate(int Id)
        {
            DataTable dates = new();
            SqlConnection conn = new(Database.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand command = new(Database.Queries.Dates.GetDate, conn);
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dates.Load(reader);
                }
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return dates;
        }
        public static string CreateDate(int IdCliente, int Service, string Day, string Hour, string ExtraServices = "")
        {
            string result = string.Empty;
            SqlConnection conn = new(Settings.Database.ConnectionString);


            try
            {
                conn.Open();

                SqlCommand command = new(Settings.Database.Queries.Dates.Create, conn);
                command.Parameters.AddWithValue("@Client", IdCliente);
                command.Parameters.AddWithValue("@Service", Service);
                command.Parameters.AddWithValue("@Day", Day);
                command.Parameters.AddWithValue("@Hour", Hour);
                command.Parameters.AddWithValue("@ExtraServices", ExtraServices);
                int rows = command.ExecuteNonQuery();
                result = rows > 0 ? "Success" : "Fail";
            }
            catch (SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }
        public static string UpdateDate(int Id, string Day, string Hour)
        {
            string result = string.Empty;
            SqlConnection conn = new(Settings.Database.ConnectionString);

            try
            {
                conn.Open();

                SqlCommand command = new(Settings.Database.Queries.Dates.Update, conn);
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Day", Day);
                command.Parameters.AddWithValue("@Hour", Hour);
                int rows = command.ExecuteNonQuery();
                result = rows > 0 ? "Success" : "Fail";
            }
            catch (SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }
        public static string DeleteDate(int Id)
        {
            string result = string.Empty;
            SqlConnection conn = new(Settings.Database.ConnectionString);

            try
            {
                conn.Open();

                SqlCommand command = new(Settings.Database.Queries.Dates.Delete, conn);
                command.Parameters.AddWithValue("@Id", Id);
                int rows = command.ExecuteNonQuery();
                result = rows > 0 ? "Success" : "Fail";
            }
            catch (SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }
    }
}
