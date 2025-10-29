using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Categorias")]
    public class CategoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        // Navigation property
        public virtual ICollection<SubcategoryModel> Subcategory { get; set; } = new List<SubcategoryModel>();
        public virtual ICollection<ArticleModel> Article { get; set; } = new List<ArticleModel>();
    }
}
