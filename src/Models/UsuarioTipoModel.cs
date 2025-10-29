using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("UsuariosTipo")]
    public class UsuarioTipoModel
    {
        [Key]
        [StringLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Descripcion { get; set; }

        public bool? Escritura { get; set; }

        public bool? Lectura { get; set; }
    }
}
