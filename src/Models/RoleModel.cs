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

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Title { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public AccessLevel SellsPermission { get; set; } = AccessLevel.None;
        public AccessLevel PurchasesPermission { get; set; } = AccessLevel.None;
        public AccessLevel ArticlePermissions { get; set; } = AccessLevel.None;
        public AccessLevel ActivityLogPermission { get; set; } = AccessLevel.None;
        public AccessLevel FinancialStatePermission { get; set; } = AccessLevel.None;
        public AccessLevel UserPermission { get; set; } = AccessLevel.None;

        public bool Active { get; set; } = true;

        // Navigation property
        public virtual ICollection<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
