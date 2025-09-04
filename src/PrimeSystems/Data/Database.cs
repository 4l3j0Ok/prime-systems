using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using PrimeSystems.Controllers;

namespace PrimeSystems.Data
{
    internal class Database
    {
        private static readonly string _connectionString = Config.sql_connection_string;

        public static int ExecuteNonQuery(string query, Dictionary<string, object>? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand(query, connection);
            if (parameters != null)
            {
                foreach (var param in parameters)
                    command.Parameters.AddWithValue(param.Key, param.Value);
            }
            Debug.WriteLine($"Ejecutando consulta: {command.CommandText}");
            return command.ExecuteNonQuery();
        }

        public static SqlDataReader ExecuteReader(string query, Dictionary<string, object>? parameters = null)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand(query, connection);
            if (parameters != null)
            {
                foreach (var param in parameters)
                    command.Parameters.AddWithValue(param.Key, param.Value);
            }
            Debug.WriteLine($"Ejecutando consulta: {command.CommandText}");
            return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
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
    }
}
