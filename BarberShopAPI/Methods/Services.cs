using BarberShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

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

                //SqlDataAdapter adapter = new SqlDataAdapter(command);
                //adapter.Fill(services);

                //adapter.Dispose();
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

        
    }
}
