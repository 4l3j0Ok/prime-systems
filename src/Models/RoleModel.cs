using System.ComponentModel.DataAnnotations;


namespace PrimeSystems.Models
{
    public class RoleModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
