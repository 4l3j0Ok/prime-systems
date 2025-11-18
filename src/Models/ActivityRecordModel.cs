using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HMovimientos")]
    public class ActivityRecordModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public string? Module { get; set; }
        public string? Action { get; set; } = string.Empty;

        public DateTime? Date { get; set; }

        [ForeignKey("Sell")]
        public int? SellId { get; set; } = null;
        [ForeignKey("Purchase")]
        public int? PurchaseId { get; set; } = null;
        [ForeignKey("Article")]
        public int? ArticleId { get; set; } = null;
        [ForeignKey("Client")]
        public int? ClientId { get; set; } = null;
        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; } = null;


        // Navigation properties
        public virtual UserModel? User { get; set; }
        public virtual SellModel? Sell { get; set; }
        public virtual PurchaseModel? Purchase { get; set; }
        public virtual ArticleModel? Article { get; set; }
        public virtual ClientModel? Client { get; set; }
        public virtual SupplierModel? Supplier { get; set; }

    }

    public static class ActivityModules
    {
        public const string Sells = "Ventas";
        public const string Purchases = "Compras";
        public const string Users = "Usuarios";
        public const string Roles = "Roles";
        public const string Articles = "Artículos";
        public const string Clients = "Clientes";
        public const string Suppliers = "Proveedores";
        public const string Financial = "Estado Contable";
    }
    public static class ActivityActions
    {
        public const string Create = "Alta";
        public const string Delete = "Baja";
        public const string Update = "Modificación";
    }
}
