using PrimeSystems.Data;
using PrimeSystems.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystems.Data
{
    internal class DbInitializer
    {
        public static UserModel? InitializeUser()
        {
            using var context = new AppDbContext();

            // Crear la base de datos y las tablas si no existen
            context.Database.EnsureCreated();

            // Seed de roles por defecto
            context.SeedDefaultRoles();

            // Crear usuario administrador si no existe
            UserModel? user = context.CreateAdminUserIfNotExists();
            return user;
        }
    }
}
