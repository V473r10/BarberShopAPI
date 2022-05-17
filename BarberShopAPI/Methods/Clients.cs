using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BarberShopAPI.Methods
{
    public class Clients
    {
        public static DataTable GetClients()
        {
            DataTable Clients = new();            
            SqlConnection conn = new(Settings.Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Settings.Database.Queries.Clients.Get, conn);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Clients.Load(reader);
                }
            }
            catch(SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
            return Clients;
            
        } 
        public static DataTable GetClientById(int Id)
        {
            DataTable Client = new();
            SqlConnection conn = new(Settings.Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Settings.Database.Queries.Clients.GetById, conn);
                command.Parameters.AddWithValue(@"Id", Id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Client.Load(reader);
                }
            }
            catch(SqlException)
            {
                throw;
            }
            finally { conn.Close(); }
            return Client;
        }
        public static string CreateClient(string Name, string Phone, string Email)
        {
            string result = null;
            
            SqlConnection conn = new(Settings.Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Settings.Database.Queries.Clients.Create, conn);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Regular", 0);
                int rows = command.ExecuteNonQuery();

                result = rows > 0 ? "Success" : "Failed";
                //if (rows > 0)
                //{
                //    result = "Success";
                //}

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
