using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HVentasDetalle")]
    public class SellDetailModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Sell")]
        public int? SellId { get; set; }

        [ForeignKey("Article")]
        public int? ArticleId { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [StringLength(255)]
        public string? Subtotal { get; set; }

        [StringLength(255)]
        public string? Discount { get; set; }

        [StringLength(255)]
        public string? Total { get; set; }
        // Navigation properties
        public virtual SellModel? Sell { get; set; }
        public virtual ArticleModel? Article { get; set; }
    }
}
