using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HCompras")]
    public class HCompraModel
    {
        [Key]
        public int IdRemito { get; set; }

        [ForeignKey("Usuario")]
        public int? CodUsuario { get; set; }

        [StringLength(255)]
        public string? FechaHora { get; set; }

        [ForeignKey("Proveedor")]
        public int? IdProveedor { get; set; }

        [StringLength(255)]
        public string? Subtotal { get; set; }

        [StringLength(255)]
        public string? Descu { get; set; }

        [StringLength(255)]
        public string? Total { get; set; }

        // Navigation properties
        public virtual UsuarioModel? Usuario { get; set; }
        public virtual ProveedorModel? Proveedor { get; set; }
        public virtual ICollection<HCompraDetalleModel> Detalles { get; set; } = new List<HCompraDetalleModel>();
    }
}
