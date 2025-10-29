using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Subcategorias")]
    public class SubcategoriaModel
    {
        [Key]
        public int IdSubcategoria { get; set; }

        [StringLength(255)]
        public string? Subcategoria { get; set; }

        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        // Navigation property
        public virtual CategoriaModel? Categoria { get; set; }
        public virtual ICollection<ArticuloModel> Articulos { get; set; } = new List<ArticuloModel>();
    }
}
