using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Clientes")]
    public class ClienteModel
    {
        [Key]
        public int IdCliente { get; set; }

        public int? Cuit { get; set; }

        [StringLength(255)]
        public string? Nombre { get; set; }

        [StringLength(255)]
        public string? Entidad { get; set; }

        [StringLength(255)]
        public string? Tel { get; set; }

        [StringLength(255)]
        public string? Mail { get; set; }
    }
}
