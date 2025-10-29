using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("UsuariosTipo")]
    public class UserTypeModel
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        public bool? Read { get; set; }

        public bool? Write { get; set; }
    }
}
