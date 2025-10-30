using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HMovimientos")]
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public int? Type { get; set; }

        public DateTime? Date { get; set; }

        // Navigation properties
        public virtual UserModel? User { get; set; }
    }
}
