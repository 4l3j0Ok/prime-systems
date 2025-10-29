using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Categorias")]
    public class CategoriaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCategoria { get; set; }

        [StringLength(255)]
        public string? Categoria { get; set; }

        // Navigation property
        public virtual ICollection<SubcategoriaModel> Subcategorias { get; set; } = new List<SubcategoriaModel>();
        public virtual ICollection<ArticuloModel> Articulos { get; set; } = new List<ArticuloModel>();
    }
}
