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
        public string? Description { get; set; } = string.Empty;

        public DateTime? Date { get; set; }

        // Navigation properties
        public virtual UserModel? User { get; set; }
    }

    public static class ActivityModules
    {
        public const string Sells = "Ventas";
        public const string Purchases = "Compras";
        public const string Users = "Usuarios";
        public const string Articles = "Artículos";
        public const string Clients = "Clientes";
        public const string Suppliers = "Proveedores";
        public const string Financial = "Estado Contable";
        public static string DescriptionTemplate(string user, string action, string module) => $"{user} realizó la acción: {action} en el módulo de {module}.";
    }
    public static class ActivityActions
    {
        public const string Created = "creó";
        public const string Updated = "actualizó";
        public const string Deleted = "eliminó";
    }
}
