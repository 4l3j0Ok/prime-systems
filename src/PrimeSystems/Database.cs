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

        public static Dictionary<string, string> CreateAdminUserIfNotExists()
        {
            string query = "USE PrimeSystems; SELECT TOP 1 * FROM Usuarios;";
            Dictionary<string, string> user = new Dictionary<string, string>();
            SqlDataReader sqlDataReader = ExecuteReader(query);
            if (!sqlDataReader.HasRows)
            {
                string username = "admin";
                string password = Utils.GenerateRandomString(12);
                query = File.ReadAllText(".\\queries\\04-insert-user.sql");
                query = query.Replace(
                    "{ DNI }",
                    "00000000"
                ).Replace(
                    "{ nombre }",
                    "Admin"
                ).Replace(
                    "{ apellido }",
                    "Admin"
                ).Replace(
                    "{ tel }",
                    "123456789"
                ).Replace(
                    "{ mail }",
                    "admin@primesystems.com"
                ).Replace(
                    "{ nombre_usuario }", username
                )
                .Replace(
                    "{ contrasena }",
                    password
                ).Replace(
                    "{ p_compra }",
                    "w"
                ).Replace(
                    "{ p_venta }",
                    "w"
                ).Replace(
                    "{ p_rrhh }",
                    "w"
                ).Replace(
                    "{ p_contable }",
                    "w"
                );
                Debug.WriteLine(query);
                ExecuteNonQuery(query);
                user["username"] = username;
                user["password"] = password;
            }
            return user;
        }
        public static string GetUserPassword(string username)
        {
            string password = "";
            string query = File.ReadAllText(".\\queries\\05-select-user-password.sql");
            query = query.Replace(
                "{ nombre_usuario }",
                username);
            SqlDataReader reader = ExecuteReader(query);
            if (reader.HasRows)
                password = reader.GetString(0);
            Debug.WriteLine(password);
            return password;

        }

    }
}
