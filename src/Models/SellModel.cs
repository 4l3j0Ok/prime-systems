using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HVentas")]
    public class SellModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [StringLength(255)]
        public string? Date { get; set; }

        [ForeignKey("Client")]
        public int? ClientId { get; set; }

        [StringLength(255)]
        public string? Subtotal { get; set; }

        [StringLength(255)]
        public string? Discount { get; set; }

        [StringLength(255)]
        public string? Total { get; set; }

        // Navigation properties
        public virtual UserModel? User { get; set; }
        public virtual ClientModel? Client { get; set; }
        public virtual ICollection<SellDetailModel> Detail { get; set; } = new List<SellDetailModel>();
    }
}
