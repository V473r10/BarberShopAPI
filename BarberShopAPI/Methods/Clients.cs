using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BarberShopAPI.Settings;

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
        public static string UpdateClient(int Id, string Name, string Phone, string Email)
        {
            string response = string.Empty;

            SqlConnection conn = new(Database.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand command = new(Database.Queries.Clients.Update, conn);
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Email", Email);

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
        public static string UpgradeClient(int Id)
        {
            string response = string.Empty;

            SqlConnection conn = new(Database.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand command = new(Database.Queries.Clients.Upgrade, conn);
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
        public static string DeleteClient(int Id)
        {
            string response = string.Empty;
            SqlConnection conn = new(Database.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand command = new(Database.Queries.Clients.Delete, conn);
                command.Parameters.AddWithValue("@Id", Id);
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "Success" : "Fail";
            }
            catch (SqlException)
            {
                response = "Conflict";
            }
            finally { conn.Close(); }
            return response;
        }

    }
}
