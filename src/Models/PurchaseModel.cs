using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HCompras")]
    public class PurchaseModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [StringLength(255)]
        public string? Date { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }

        [StringLength(255)]
        public string? Subtotal { get; set; }

        [StringLength(255)]
        public string? Discount { get; set; }

        [StringLength(255)]
        public string? Total { get; set; }

        // Navigation properties
        public virtual UserModel? User { get; set; }
        public virtual SupplierModel? Supplier { get; set; }
        public virtual ICollection<PurchaseDetailModel> Detail { get; set; } = new List<PurchaseDetailModel>();
    }
}
