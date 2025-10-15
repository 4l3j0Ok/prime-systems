using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeSystems.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? PersonId { get; set; }

        public byte[]? ProfilePicture { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        // Propiedad de navegación sin NotMapped - Entity Framework la manejará correctamente
        public virtual RoleModel? Role { get; set; }

        public bool IsActive { get; set; } = true;
    }
}