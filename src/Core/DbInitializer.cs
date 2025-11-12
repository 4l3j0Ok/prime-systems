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

            // Verificar variable de entorno
            string? clearDb = Environment.GetEnvironmentVariable("CLEAR_DB_ON_STARTUP");

            if (clearDb?.ToLower() == "true")
            {
                Console.WriteLine("Limpiando base de datos...");
                context.Database.EnsureDeleted();
                Console.WriteLine("Base de datos recreada.");
            }
            context.Database.EnsureCreated();
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
