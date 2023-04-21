﻿using Npgsql;
using System.Threading.Tasks;

namespace TNKCars.DataAccess.DbHelpers
{
    public static class DatabaseUtility
    {
        public static async Task<NpgsqlConnection> EstablishConnection()
        {
            var connString = GetConnectionString();
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            await connection.OpenAsync();
            return connection;
        }

        public static string GetConnectionString()
        {
            // Hard coded for now
            //string user = "postgres";
            //string password = "password";
            return FormatConnectionString();
        }

        public static string FormatConnectionString()
        {
            return $"Host=localhost;Username=postgres;Password=1999;Database=postgres";
        }

        //public static string FormatConnectionString(ref string username, 
        //    ref string password, ref string networkLocation, ref string port, ref string dbName)
        //{
        //    // postgresql://[user[:password]@][netloc][:port][/dbname][?param1=value1&...]
        //    return $"postgresql://localhost";
        //}
    }
}
