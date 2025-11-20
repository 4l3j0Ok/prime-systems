using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Clientes")]
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }

        public int? Cuit { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(100)]
        public string? Entity { get; set; }

        [StringLength(100)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(500)]
        public string? Title { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public bool Active { get; set; } = true;

        // Navigation property
        public virtual ICollection<SellModel> Sells { get; set; } = new List<SellModel>();
    }
}
