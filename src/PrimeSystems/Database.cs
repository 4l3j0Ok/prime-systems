using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace PrimeSystems
{
    internal class Database
    {
        public static bool CheckConnection()
        {
            using (SqlConnection connection = new SqlConnection(Config.sql_connection_string))
            {
                try
                {
                    Debug.WriteLine($"Intentando conectarse a la base de datos con el connection string {Config.sql_connection_string}");
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                        return true;
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"Error al conectarse a la base de datos: {ex.Message}");
                }
                return false;
            }
        }
        public static void CreateDatabaseIfNotExists()
        {
            using (SqlConnection connection = new SqlConnection(Config.sql_connection_string))
            {
                try
                {
                    connection.Open();
                    string createDbQuery = File.ReadAllText(".\\queries\\01-create-databases.sql");
                    Debug.WriteLine($"Ejecutando consulta para crear la base de datos: {createDbQuery}");
                    using (SqlCommand command = new SqlCommand(createDbQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"Error al crear la base de datos: {ex.Message}");
                }
            }
        }
    }
}
