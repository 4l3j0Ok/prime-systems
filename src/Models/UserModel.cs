using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    [Table("Usuarios")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        public int? PersonId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string? PasswordHash { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? Phone { get; set; }

        public byte[]? ProfilePicture { get; set; }

        [StringLength(20)]
        [ForeignKey("Role")]
        public string? RoleId { get; set; }

        [StringLength(500)]
        public string? Title { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public bool Active { get; set; } = true;

        // Navigation property
        public virtual RoleModel? Role { get; set; }
    }
}