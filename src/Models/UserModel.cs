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
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? LastName { get; set; }

        [StringLength(255)]
        public string? Phone { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        public byte[]? ProfilePicture { get; set; }

        [StringLength(10)]
        [ForeignKey("UserType")]
        public string? UserTypeId { get; set; }

        // Navigation properties
        public virtual UserTypeModel? UserType { get; set; }

    }
}