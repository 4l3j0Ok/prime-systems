using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HVentasDetalle")]
    public class HVentaDetalleModel
    {
        [Key]
        public int IdDetRemito { get; set; }

        [ForeignKey("Venta")]
        public int? IdRemito { get; set; }

        [ForeignKey("Articulo")]
        public int? IdArticulo { get; set; }

        [StringLength(255)]
        public string? Descr { get; set; }

        [StringLength(255)]
        public string? PUnit { get; set; }

        [StringLength(255)]
        public string? Cant { get; set; }

        [StringLength(255)]
        public string? PXCant { get; set; }

        // Navigation properties
        public virtual HVentaModel? Venta { get; set; }
        public virtual ArticuloModel? Articulo { get; set; }
    }
}
