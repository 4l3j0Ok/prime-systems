using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Stock")]
    public class StockModel
    {
        [Key]
        public int CodStock { get; set; }

        [ForeignKey("Articulo")]
        public int? IdArticulo { get; set; }

        public int? Cantidad { get; set; }

        [StringLength(255)]
        public string? Costo { get; set; }

        public int? Ganancia { get; set; }

        // Navigation property
        public virtual ArticuloModel? Articulo { get; set; }
    }
}
