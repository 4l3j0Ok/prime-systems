using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PrimeSystems.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Config.sql_connection_string);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación User-Role
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);


            // Configuración de índices únicos
            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.PersonId)
                .IsUnique();


            // Mapeo de nombres de tabla (si es necesario mantener compatibilidad)
            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<RoleModel>().ToTable("Role");
            base.OnModelCreating(modelBuilder);
        }

        public void SeedDefaultRoles()
        {
            foreach (var roleName in Config.defaultRoles)
            {
                if (!this.Roles.Any(r => r.Name == roleName))
                {
                    this.Roles.Add(new RoleModel { Name = roleName });
                }
            }
            this.SaveChanges();
        }

        public UserModel? GetUserByUsername(string username)
        {
            return this.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username);
        }

        public List<UserModel> GetAllUsersWithRoles()
        {
            return this.Users
                .Include(u => u.Role)
                .Where(u => u.IsActive)
                .ToList();
        }

        public UserModel? CreateAdminUserIfNotExists()
        {
            if (this.Users.Any()) return null;

            var adminRole = this.Roles.FirstOrDefault(r => r.Name == "Administrador");
            if (adminRole == null) return null;

            var user = new UserModel
            {
                Username = "admin",
                Password = Utils.GenerateRandomString(12),
                Name = "Administrador",
                Surname = "Sistema",
                PersonId = "10000000",
                Email = "email@admin.com",
                Phone = "2224123456",
                RoleId = adminRole.Id,
                ProfilePicture = Utils.ImageToByteArray(Config.default_profile_picture),
                IsActive = true
            };

            this.Users.Add(user);
            this.SaveChanges();
            return user;
        }
    }
}
