using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Articulos")]
    public class ArticuloModel
    {
        [Key]
        public int IdArticulo { get; set; }

        [Required]
        [StringLength(255)]
        public string CodArticulo { get; set; } = string.Empty;

        [StringLength(255)]
        public string? ArtDesc { get; set; }

        [ForeignKey("Categoria")]
        public int? CodCategoria { get; set; }

        [ForeignKey("Subcategoria")]
        public int? CodSubcat { get; set; }

        [ForeignKey("Proveedor")]
        public int? IdProveedor { get; set; }

        // Navigation properties
        public virtual CategoriaModel? Categoria { get; set; }
        public virtual SubcategoriaModel? Subcategoria { get; set; }
        public virtual ProveedorModel? Proveedor { get; set; }
        public virtual ICollection<StockModel> Stock { get; set; } = new List<StockModel>();
    }
}
