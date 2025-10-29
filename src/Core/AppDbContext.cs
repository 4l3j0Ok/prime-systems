using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PrimeSystems.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Usuarios { get; set; }
        public DbSet<UserTypeModel> UsuariosTipo { get; set; }
        public DbSet<ClientModel> Clientes { get; set; }
        public DbSet<CategoryModel> Categorias { get; set; }
        public DbSet<SupplierModel> Proveedores { get; set; }
        public DbSet<SubcategoryModel> Subcategorias { get; set; }
        public DbSet<ArticleModel> Articulos { get; set; }
        public DbSet<StockModel> Stock { get; set; }
        public DbSet<TransactionModel> HMovimientos { get; set; }
        public DbSet<PurchaseModel> HCompras { get; set; }
        public DbSet<PurchaseDetailModel> HComprasDetalle { get; set; }
        public DbSet<SellModel> HVentas { get; set; }
        public DbSet<SellDetailModel> HVentasDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.sql_connection_string);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relación User-UsuarioTipo
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.UserType)
                .WithMany()
                .HasForeignKey(u => u.UserTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de índices únicos para Users
            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Configuración de relaciones para Subcategoria
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

            modelBuilder.Entity<ArticleModel>()
                .HasOne(a => a.Supplier)
                .WithMany(p => p.Articles)
                .HasForeignKey(a => a.SupplierId)
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
                .HasOne(d => d.Compra)
                .WithMany(c => c.Detail)
                .HasForeignKey(d => d.IdRemito)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseDetailModel>()
                .HasOne(d => d.Articulo)
                .WithMany()
                .HasForeignKey(d => d.IdArticulo)
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

        public void SeedDefaultUsuariosTipo()
        {
            if (!UsuariosTipo.Any())
            {
                UsuariosTipo.AddRange(
                    new UserTypeModel { Id = "ADMIN", Description = "Administrador", Read = true, Write = true },
                    new UserTypeModel { Id = "VENDOR", Description = "Vendedor", Read = false, Write = true },
                    new UserTypeModel { Id = "MANAGER", Description = "Gerente", Read = true, Write = true }
                );
                SaveChanges();
            }
        }

        public UserModel? GetUserByUsername(string username)
        {
            return Usuarios
                .Include(u => u.UserType)
                .FirstOrDefault(u => u.Username == username);
        }

        public List<UserModel> GetAllUsersWithRoles()
        {
            return Usuarios
                .Include(u => u.UserType)
                .ToList();
        }

        public UserModel? CreateAdminUserIfNotExists()
        {
            if (Usuarios.Any()) return null;

            var adminTipo = UsuariosTipo.FirstOrDefault(ut => ut.Id == "ADMIN");

            var user = new UserModel
            {
                Username = "admin",
                PasswordHash = Utils.GenerateRandomString(12),
                Name = "Administrador",
                LastName = "Sistema",
                PersonId = 10000000,
                Email = "email@admin.com",
                Phone = "2224123456",
                UserTypeId = adminTipo?.Id,
                ProfilePicture = Utils.ImageToByteArray(Config.default_profile_picture)
            };

            Usuarios.Add(user);
            SaveChanges();
            return user;
        }
    }
}
