using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Stock")]
    public class StockModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Article")]
        public int? ArticleId { get; set; }

        public int? Stock { get; set; }

        [StringLength(255)]
        public string? Cost { get; set; }

        public int? Profit { get; set; }

        // Navigation properties
        public virtual ArticleModel? Article { get; set; }
    }
}
