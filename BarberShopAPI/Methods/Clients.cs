using System.Data.SqlClient;

namespace BarberShopAPI.Methods
{
    public class Clients
    {
        public static string CreateClient(string Name, string Phone, string Email)
        {
            string result = null;
            
            SqlConnection conn = new(Settings.Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Settings.Database.Queries.Clients.CreateClient, conn);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Regular", 0);
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    result = "Success";
                }

            }
            catch(SqlException)
            {
                throw;
            }
            finally { conn.Close(); }

            return result;
        }
    }
}
