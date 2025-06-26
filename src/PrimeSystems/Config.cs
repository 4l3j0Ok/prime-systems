using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystems
{
    internal class Config
    {
        public static string sql_connection_string = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ?? "";
        public static string sql_database_name = "PrimeSystems";
        public static string random_password_characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':,.<>?/~`";
    }
}
