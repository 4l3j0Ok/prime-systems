using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    public enum AccessLevel
    {
        None = 'N',
        Read = 'R',
        Write = 'W',
    }

    [Table("UsuariosTipo")]
    public class RoleModel
    {
        [Key]
        [StringLength(20)]
        public string Id { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Name { get; set; }
        public AccessLevel SellsPermission { get; set; } = AccessLevel.None;
        public AccessLevel PurchasesPermission { get; set; } = AccessLevel.None;
        public AccessLevel FinancialStatePermission { get; set; } = AccessLevel.None;
        public AccessLevel UserPermission { get; set; } = AccessLevel.None;
    }
}
