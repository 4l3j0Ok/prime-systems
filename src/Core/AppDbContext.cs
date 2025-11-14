using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PrimeSystems.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<RoleModel> UserType { get; set; }
        public DbSet<ClientModel> Client { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<SupplierModel> Supplier { get; set; }
        public DbSet<SubcategoryModel> Subcategory { get; set; }
        public DbSet<ArticleModel> Article { get; set; }
        public DbSet<StockModel> Stock { get; set; }
        public DbSet<TransactionModel> Transaction { get; set; }
        public DbSet<PurchaseModel> Purchase { get; set; }
        public DbSet<PurchaseDetailModel> PurchaseDetail { get; set; }
        public DbSet<SellModel> Sell { get; set; }
        public DbSet<SellDetailModel> SellDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.sql_connection_string);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relación User-UsuarioTipo
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de índices únicos para Users
            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Configuración de relaciones para Subcategory
            modelBuilder.Entity<SubcategoryModel>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Subcategory)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para Articulo
            modelBuilder.Entity<ArticleModel>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Article)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ArticleModel>()
                .HasOne(a => a.Subcategory)
                .WithMany(s => s.Articles)
                .HasForeignKey(a => a.SubcategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para Stock
            modelBuilder.Entity<StockModel>()
                .HasOne(s => s.Article)
                .WithMany(a => a.Stock)
                .HasForeignKey(s => s.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Movimientos
            modelBuilder.Entity<TransactionModel>()
                .HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Compras
            modelBuilder.Entity<PurchaseModel>()
                .HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseModel>()
                .HasOne(h => h.Supplier)
                .WithMany()
                .HasForeignKey(h => h.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Compras_Detalle
            modelBuilder.Entity<PurchaseDetailModel>()
                .HasOne(d => d.Purchase)
                .WithMany(c => c.Detail)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseDetailModel>()
                .HasOne(d => d.Article)
                .WithMany()
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Ventas
            modelBuilder.Entity<SellModel>()
                .HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SellModel>()
                .HasOne(h => h.Client)
                .WithMany()
                .HasForeignKey(h => h.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Ventas_Detalle
            modelBuilder.Entity<SellDetailModel>()
                .HasOne(d => d.Sell)
                .WithMany(v => v.Detail)
                .HasForeignKey(d => d.SellId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SellDetailModel>()
                .HasOne(d => d.Article)
                .WithMany()
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public void SeedDefaultRoles()
        {
            if (!UserType.Any())
            {
                UserType.AddRange(
                    new RoleModel
                    {
                        Id = "admin",
                        Name = "Administrador",
                        PurchasesPermission = AccessLevel.Write,
                        SellsPermission = AccessLevel.Write,
                        FinancialStatePermission = AccessLevel.Write,
                        UserPermission = AccessLevel.Write
                    },
                    new RoleModel
                    {
                        Id = "vendedor",
                        Name = "Vendedor",
                        PurchasesPermission = AccessLevel.Read,
                        SellsPermission = AccessLevel.Write,
                        FinancialStatePermission = AccessLevel.Read,
                        UserPermission = AccessLevel.None
                    },
                    // acceso a compras
                    new RoleModel
                    {
                        Id = "gestor_compras",
                        Name = "Gestor de Compras",
                        PurchasesPermission = AccessLevel.Write,
                        SellsPermission = AccessLevel.Read,
                        FinancialStatePermission = AccessLevel.Read,
                        UserPermission = AccessLevel.None
                    }
                );
                SaveChanges();
            }
        }

        public UserModel? GetUserByUsername(string username)
        {
            return User
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username);
        }

        public List<UserModel> GetAllUsersWithRoles()
        {
            return User
                .Include(u => u.Role)
                .ToList();
        }

        public UserModel? CreateAdminUserIfNotExists()
        {
            if (User.Any()) return null;

            var adminTipo = UserType.FirstOrDefault(ut => ut.Id == "admin");

            var user = new UserModel
            {
                Username = "admin",
                PasswordHash = Utils.GenerateRandomString(12),
                Name = "Administrador",
                LastName = "Sistema",
                PersonId = 10000000,
                Email = "email@admin.com",
                Phone = "2224123456",
                RoleId = adminTipo?.Id,
                ProfilePicture = Utils.ImageToByteArray(Config.default_profile_picture)
            };

            User.Add(user);
            SaveChanges();
            return user;
        }
    }
}
