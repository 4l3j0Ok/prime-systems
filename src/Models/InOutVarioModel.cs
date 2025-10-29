using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("InOutVarios")]
    public class InOutVarioModel
    {
        [Key]
        public int IdMovimiento { get; set; }

        [ForeignKey("Usuario")]
        public int? CodUsuario { get; set; }

        [StringLength(255)]
        public string? Tipo { get; set; }

        [StringLength(255)]
        public string? Detalle { get; set; }

        [StringLength(255)]
        public string? Monto { get; set; }

        [StringLength(255)]
        public string? Fecha { get; set; }

        // Navigation property
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
