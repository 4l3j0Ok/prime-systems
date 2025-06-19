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
        public static void ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(Config.sql_connection_string))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        Debug.WriteLine($"Consulta ejecutada correctamente: {query}");
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                }
            }
        }

        public static SqlDataReader ExecuteReader(string query)
        {
            SqlConnection connection = new SqlConnection(Config.sql_connection_string);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                Debug.WriteLine($"Consulta ejecutada correctamente: {query}");
                return reader;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                connection.Close();
                throw;
            }
        }
        public static void CheckConnection()
        {
            using (SqlConnection connection = new SqlConnection(Config.sql_connection_string))
            {
                try
                {
                    Debug.WriteLine($"Intentando conectarse a la base de datos con el connection string {Config.sql_connection_string}");
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"Error al conectarse a la base de datos: {ex.Message}");
                    throw new Exception("No se pudo establecer una conexión con la base de datos. Por favor, verifica la configuración.", ex);
                }
            }
        }
        public static void CreateDatabaseIfNotExists()
        {
            string createDbQuery = File.ReadAllText(".\\queries\\01-create-databases.sql");
            Debug.WriteLine($"Ejecutando consulta para crear la base de datos: {createDbQuery}");
            ExecuteNonQuery(createDbQuery);
        }

        public static void CreateTablesIfNotExists()
        {
            string createTablesQuery = File.ReadAllText(".\\queries\\02-create-tables.sql");
            Debug.WriteLine($"Ejecutando consulta para crear las tablas: {createTablesQuery}");
            ExecuteNonQuery(createTablesQuery);
        }
    }
}
