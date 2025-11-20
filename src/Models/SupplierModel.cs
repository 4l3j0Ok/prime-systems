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

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(100)]
        public string? ContactName { get; set; }

        [StringLength(100)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(500)]
        public string? Title { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public bool Active { get; set; } = true;

        // Navigation properties
        public virtual ICollection<ArticleModel> Articles { get; set; } = new List<ArticleModel>();
        public virtual ICollection<PurchaseModel> Purchases { get; set; } = new List<PurchaseModel>();
    }
}
