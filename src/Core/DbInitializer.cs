using PrimeSystems.Core;
using PrimeSystems.Models;
using System;

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

        public static UserModel? InitializeUser()
        {
            using var context = new AppDbContext();
            // Sembramos los tipos de usuario por defecto porque
            // sin ellos no se puede crear el usuario admin
            context.SeedDefaultRoles();
            UserModel? user = context.CreateAdminUserIfNotExists();
            return user;
        }
    }
}
