using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Proveedores")]
    public class SupplierModel
    {
        [Key]
        public int Id { get; set; }

        public int? Cuit { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? ContactName { get; set; }

        [StringLength(255)]
        public string? Phone { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        // Navigation property
        public virtual ICollection<ArticleModel> Articles { get; set; } = new List<ArticleModel>();
    }
}
