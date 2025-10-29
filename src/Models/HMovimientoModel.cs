using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("HMovimientos")]
    public class HMovimientoModel
    {
        [Key]
        public int IdHistorico { get; set; }

        [ForeignKey("Usuario")]
        public int? IdUsuario { get; set; }

        public int? TipoMovimiento { get; set; }

        [StringLength(255)]
        public string? RegAntes { get; set; }

        [StringLength(255)]
        public string? RegDespues { get; set; }

        public DateTime? FechaHora { get; set; }

        // Navigation property
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
