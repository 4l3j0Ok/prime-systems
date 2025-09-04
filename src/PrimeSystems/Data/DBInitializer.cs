using PrimeSystems.Data;
using PrimeSystems.Models;
using PrimeSystems.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PrimeSystems.Data
{
    internal class DBInitializer
    {
        public static string createUsersTable = @$"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuarios' AND xtype='U')
            CREATE TABLE Usuarios (
                id INT PRIMARY KEY IDENTITY(1,1),
                username NVARCHAR(50) NOT NULL,
                password NVARCHAR(255) NOT NULL,
                name NVARCHAR(100) NOT NULL,
                surname NVARCHAR(100) NOT NULL,
                phone NVARCHAR(50) NOT NULL,
                email NVARCHAR(100) NOT NULL,
                person_id INT NOT NULL,
                p_buy CHAR(1) NOT NULL,
                p_sells CHAR(1) NOT NULL,
                p_hhrr CHAR(1) NOT NULL,
                p_contable CHAR(1) NOT NULL
            );";
        public static void CreateDatabaseIfNotExists()
        {
            var builder = new SqlConnectionStringBuilder(Config.sql_connection_string);

            // Siempre nos conectamos a master para comprobar/crear la DB
            string masterConnection = $"Server={builder.DataSource};Database=master;User Id={builder.UserID};Password={builder.Password};TrustServerCertificate=True";

            using (var connection = new SqlConnection(masterConnection))
            {
                connection.Open();

                string checkDbQuery = $@"
                    IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = '{Config.sql_database_name}')
                    BEGIN
                        CREATE DATABASE [{Config.sql_database_name}];
                    END";

                using (var command = new SqlCommand(checkDbQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void CreateTablesIfNotExists()
        {
            Debug.WriteLine($"Ejecutando consulta para crear la tabla de usuarios: {createUsersTable}");
            Database.ExecuteNonQuery(createUsersTable);
        }
    }
}
