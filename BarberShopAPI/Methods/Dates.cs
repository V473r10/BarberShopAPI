using System.Data.SqlClient;

namespace BarberShopAPI.Methods
{
    public class Dates
    {
        public static string CreateDate(int IdCliente, int Service, string Day, string Hour, string ExtraServices = "")
        {
            string result = null;

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
                if (rows > 0)
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
    }
}
