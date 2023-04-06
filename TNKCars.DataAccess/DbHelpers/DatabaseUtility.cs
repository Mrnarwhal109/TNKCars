using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCars.DataAccess.DbHelpers
{
    internal static class DatabaseUtility
    {
        public static string GetConnectionString()
        {
            // Hard coded for now
            //string user = "postgres";
            //string password = "password";
            return FormatConnectionString();
        }

        public static string FormatConnectionString()
        {
            return $"postgresql://localhost";
        }

        public static string FormatConnectionString(ref string username, 
            ref string password, ref string networkLocation, ref string port, ref string dbName)
        {
            // postgresql://[user[:password]@][netloc][:port][/dbname][?param1=value1&...]
            return $"postgresql://localhost";
        }
    }
}
