using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PrimeSystems.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<UsuarioTipoModel> UsuariosTipo { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProveedorModel> Proveedores { get; set; }
        public DbSet<SubcategoriaModel> Subcategorias { get; set; }
        public DbSet<ArticuloModel> Articulos { get; set; }
        public DbSet<StockModel> Stock { get; set; }
        public DbSet<HMovimientoModel> HMovimientos { get; set; }
        public DbSet<InOutVarioModel> InOutVarios { get; set; }
        public DbSet<HCompraModel> HCompras { get; set; }
        public DbSet<HCompraDetalleModel> HComprasDetalle { get; set; }
        public DbSet<HVentaModel> HVentas { get; set; }
        public DbSet<HVentaDetalleModel> HVentasDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.sql_connection_string);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relación User-UsuarioTipo
            modelBuilder.Entity<UsuarioModel>()
                .HasOne(u => u.UsuarioTipo)
                .WithMany()
                .HasForeignKey(u => u.UsuarioTipoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de índices únicos para Users
            modelBuilder.Entity<UsuarioModel>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            // Configuración de relaciones para Subcategoria
            modelBuilder.Entity<SubcategoriaModel>()
                .HasOne(s => s.Categoria)
                .WithMany(c => c.Subcategorias)
                .HasForeignKey(s => s.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para Articulo
            modelBuilder.Entity<ArticuloModel>()
                .HasOne(a => a.Categoria)
                .WithMany(c => c.Articulos)
                .HasForeignKey(a => a.CodCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ArticuloModel>()
                .HasOne(a => a.Subcategoria)
                .WithMany(s => s.Articulos)
                .HasForeignKey(a => a.CodSubcat)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ArticuloModel>()
                .HasOne(a => a.Proveedor)
                .WithMany(p => p.Articulos)
                .HasForeignKey(a => a.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para Stock
            modelBuilder.Entity<StockModel>()
                .HasOne(s => s.Articulo)
                .WithMany(a => a.Stock)
                .HasForeignKey(s => s.IdArticulo)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Movimientos
            modelBuilder.Entity<HMovimientoModel>()
                .HasOne(h => h.Usuario)
                .WithMany()
                .HasForeignKey(h => h.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para In_Out_Varios
            modelBuilder.Entity<InOutVarioModel>()
                .HasOne(i => i.Usuario)
                .WithMany()
                .HasForeignKey(i => i.CodUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Compras
            modelBuilder.Entity<HCompraModel>()
                .HasOne(h => h.Usuario)
                .WithMany()
                .HasForeignKey(h => h.CodUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HCompraModel>()
                .HasOne(h => h.Proveedor)
                .WithMany()
                .HasForeignKey(h => h.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Compras_Detalle
            modelBuilder.Entity<HCompraDetalleModel>()
                .HasOne(d => d.Compra)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.IdRemito)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HCompraDetalleModel>()
                .HasOne(d => d.Articulo)
                .WithMany()
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Ventas
            modelBuilder.Entity<HVentaModel>()
                .HasOne(h => h.Usuario)
                .WithMany()
                .HasForeignKey(h => h.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HVentaModel>()
                .HasOne(h => h.Cliente)
                .WithMany()
                .HasForeignKey(h => h.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relaciones para H_Ventas_Detalle
            modelBuilder.Entity<HVentaDetalleModel>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.IdRemito)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HVentaDetalleModel>()
                .HasOne(d => d.Articulo)
                .WithMany()
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public void SeedDefaultUsuariosTipo()
        {
            if (!UsuariosTipo.Any())
            {
                UsuariosTipo.AddRange(
                    new UsuarioTipoModel { Id = "ADMIN", Descripcion = "Administrador", Escritura = true, Lectura = true },
                    new UsuarioTipoModel { Id = "VENDOR", Descripcion = "Vendedor", Escritura = false, Lectura = true },
                    new UsuarioTipoModel { Id = "MANAGER", Descripcion = "Gerente", Escritura = true, Lectura = true }
                );
                SaveChanges();
            }
        }

        public UsuarioModel? GetUserByUsername(string username)
        {
            return Usuarios
                .Include(u => u.UsuarioTipo)
                .FirstOrDefault(u => u.NombreUsuario == username);
        }

        public List<UsuarioModel> GetAllUsersWithRoles()
        {
            return Usuarios
                .Include(u => u.UsuarioTipo)
                .ToList();
        }

        public UsuarioModel? CreateAdminUserIfNotExists()
        {
            if (Usuarios.Any()) return null;

            var adminTipo = UsuariosTipo.FirstOrDefault(ut => ut.Id == "ADMIN");

            var user = new UsuarioModel
            {
                NombreUsuario = "admin",
                Contrasena = Utils.GenerateRandomString(12),
                Nombre = "Administrador",
                Apellido = "Sistema",
                Dni = 10000000,
                Mail = "email@admin.com",
                Tel = "2224123456",
                UsuarioTipoId = adminTipo?.Id,
                Foto = Utils.ImageToByteArray(Config.default_profile_picture)
            };

            Usuarios.Add(user);
            SaveChanges();
            return user;
        }
    }
}
