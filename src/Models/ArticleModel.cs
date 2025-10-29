using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Articulos")]
    public class ArticleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        [ForeignKey("Categoria")]
        public int? CategoryId { get; set; }

        [ForeignKey("Subcategory")]
        public int? SubcategoryId { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }

        // Navigation properties
        public virtual CategoryModel? Category { get; set; }
        public virtual SubcategoryModel? Subcategory { get; set; }
        public virtual SupplierModel? Supplier { get; set; }
        public virtual ICollection<StockModel> Stock { get; set; } = new List<StockModel>();
    }
}
