using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Proveedores")]
    public class ProveedorModel
    {
        [Key]
        public int IdProveedor { get; set; }

        public int? Cuit { get; set; }

        [StringLength(255)]
        public string? Proveedor { get; set; }

        [StringLength(255)]
        public string? Nombre { get; set; }

        [StringLength(255)]
        public string? Tel { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        // Navigation property
        public virtual ICollection<ArticuloModel> Articulos { get; set; } = new List<ArticuloModel>();
    }
}
