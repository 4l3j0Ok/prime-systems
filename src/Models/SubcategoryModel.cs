using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Subcategorias")]
    public class SubcategoryModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Navigation properties
        public virtual CategoryModel? Category { get; set; }
        public virtual ICollection<ArticleModel> Articles { get; set; } = new List<ArticleModel>();
    }
}
