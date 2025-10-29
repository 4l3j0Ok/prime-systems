using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HVentas")]
    public class HVentaModel
    {
        [Key]
        public int IdRemito { get; set; }

        [ForeignKey("Usuario")]
        public int? IdUsuario { get; set; }

        [StringLength(255)]
        public string? FechaHora { get; set; }

        [ForeignKey("Cliente")]
        public int? IdCliente { get; set; }

        [StringLength(255)]
        public string? Subtotal { get; set; }

        [StringLength(255)]
        public string? Descu { get; set; }

        [StringLength(255)]
        public string? Total { get; set; }

        // Navigation properties
        public virtual UsuarioModel? Usuario { get; set; }
        public virtual ClienteModel? Cliente { get; set; }
        public virtual ICollection<HVentaDetalleModel> Detalles { get; set; } = new List<HVentaDetalleModel>();
    }
}
