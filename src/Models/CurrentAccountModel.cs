using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("CuentasCorrientes")]
    public class CurrentAccountModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EntityId { get; set; }

        [Required]
        public CurrentAccountType EntityType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0;

        public bool Active { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        [StringLength(500)]
        public string? Title { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public virtual ICollection<CurrentAccountMovementModel> Movements { get; set; } = new List<CurrentAccountMovementModel>();

        public string EntityName => EntityType switch
        {
            CurrentAccountType.Client => $"Cliente #{EntityId}",
            CurrentAccountType.Supplier => $"Proveedor #{EntityId}",
            CurrentAccountType.User => $"Usuario #{EntityId}",
            _ => $"Entidad #{EntityId}"
        };
    }

    public enum CurrentAccountType
    {
        Client = 1,
        Supplier = 2,
        User = 3
    }
}