using System.ComponentModel.DataAnnotations;

namespace CertificateAPI.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(30)]
        public string Name { get; set; } = null!;

        public ICollection<UserRole>? UserRoles { get; set; }
    }
}