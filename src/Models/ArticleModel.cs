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
        [StringLength(100)]
        public string Code { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [StringLength(500)]
        public string? Title { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("Subcategory")]
        public int? SubcategoryId { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }

        public bool Active { get; set; } = true;

        // Navigation properties
        public virtual CategoryModel? Category { get; set; }
        public virtual SubcategoryModel? Subcategory { get; set; }
        public virtual SupplierModel? Supplier { get; set; }
        public virtual StockModel? Stock { get; set; }
    }
}
