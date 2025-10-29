using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HComprasDetalle")]
    public class PurchaseDetailModel
    {
        [Key]
        public int IdDetRemito { get; set; }

        [ForeignKey("Compra")]
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
        public virtual PurchaseModel? Compra { get; set; }
        public virtual ArticleModel? Articulo { get; set; }
    }
}
