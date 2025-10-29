using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [Key]
        public int IdUsuario { get; set; }

        public int? Dni { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Nombre { get; set; }

        [StringLength(255)]
        public string? Apellido { get; set; }

        [StringLength(255)]
        public string? Tel { get; set; }

        [StringLength(255)]
        public string? Mail { get; set; }

        [Required]
        [StringLength(255)]
        public string Contrasena { get; set; } = string.Empty;

        [StringLength(1)]
        public string? PCompra { get; set; }

        [StringLength(1)]
        public string? PVenta { get; set; }

        [StringLength(1)]
        public string? PRrhh { get; set; }

        [StringLength(1)]
        public string? PContable { get; set; }
        //Imagen de perfil
        public byte[]? Foto { get; set; }

        [StringLength(10)]
        [ForeignKey("UsuarioTipo")]
        public string? UsuarioTipoId { get; set; }

        public virtual UsuarioTipoModel? UsuarioTipo { get; set; }

    }
}