using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertificateAPI.Models
{
    public class UserCertificate
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime DateReceived { get; set; } = DateTime.UtcNow;
        public string? ScoreOrHours { get; set; }
    }
}