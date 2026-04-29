using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("CuentasCorrientesMovimientos")]
    public class CurrentAccountMovementModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CurrentAccountId { get; set; }

        [Required]
        public MovementType Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [StringLength(500)]
        public string? Reference { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int? UserId { get; set; }

        public int? RelatedSellId { get; set; }

        public int? RelatedPurchaseId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceBefore { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceAfter { get; set; }

        public virtual CurrentAccountModel? CurrentAccount { get; set; }

        public virtual UserModel? User { get; set; }

        public virtual SellModel? RelatedSell { get; set; }

        public virtual PurchaseModel? RelatedPurchase { get; set; }
    }

    public enum MovementType
    {
        Credit = 1,
        Debit = 2,
        Payment = 3,
        Charge = 4
    }
}