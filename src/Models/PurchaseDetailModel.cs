using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HComprasDetalle")]
    public class PurchaseDetailModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Purchase")]
        public int? PurchaseId { get; set; }

        [ForeignKey("Article")]
        public int? ArticleId { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [StringLength(255)]
        public string? UnitPrice { get; set; }

        [StringLength(255)]
        public string? Quantity { get; set; }

        // Navigation properties
        public virtual PurchaseModel? Purchase { get; set; }
        public virtual ArticleModel? Article { get; set; }
    }
}
