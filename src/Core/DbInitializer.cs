using PrimeSystems.Core;
using PrimeSystems.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace PrimeSystems.Core
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            using var context = new AppDbContext();

            // Verificar variable de entorno para limpiar DB
            string? clearDb = Environment.GetEnvironmentVariable("CLEAR_DB_ON_STARTUP");

            if (clearDb?.ToLower() == "true")
            {
                Console.WriteLine("Limpiando base de datos...");
                context.Database.EnsureDeleted();
                Console.WriteLine("Base de datos recreada.");
            }

            context.Database.EnsureCreated();

            // Verificar variable de entorno para poblar DB con datos de prueba
            string? populateDb = Environment.GetEnvironmentVariable("POPULATE_DB_ON_STARTUP");

            if (populateDb?.ToLower() == "true")
            {
                Console.WriteLine("Iniciando población de base de datos con datos de prueba...");
                Tests tests = new Tests(context);
                bool success = tests.PopulateDB();

                if (success)
                {
                    Console.WriteLine("Base de datos poblada exitosamente con datos de prueba!");
                }
                else
                {
                    Console.WriteLine("Error al poblar la base de datos con datos de prueba.");
                }
            }
        }


        public static UserModel? InitializeUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password cannot be empty.");
            }

            using var context = new AppDbContext();

            context.SeedDefaultRoles();

            if (context.User.Any())
            {
                return null;
            }

            var adminRole = context.UserType.FirstOrDefault(ut => ut.Id == "admin");

            var user = new UserModel
            {
                Username = username,
                Password = password,
                Name = "Administrador",
                LastName = "Sistema",
                PersonId = 10000000,
                Email = "admin@primesystems.com",
                Phone = "2224123456",
                RoleId = adminRole?.Id,
                ProfilePicture = Utils.ImageToByteArray(Config.default_profile_picture)
            };

            context.User.Add(user);
            context.SaveChanges();

            return user;
        }

        public static (bool success, string? errorMessage) TestConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return (false, "La cadena de conexión no puede estar vacía.");
            }

            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                using var context = new AppDbContext(optionsBuilder.Options);

                // Try to open connection and execute a simple query
                bool canConnect = context.Database.CanConnect();

                if (!canConnect)
                {
                    return (false, "No se pudo conectar a la base de datos. Verifique la cadena de conexión.");
                }

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"Error al conectar: {ex.Message}");
            }
        }
    }
}
