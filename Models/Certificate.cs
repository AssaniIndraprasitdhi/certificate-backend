using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;


namespace CertificateAPI.Models
{
    public class Certificate
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string CertificateName { get; set; } = null!;

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        public string IssuingOrganization { get; set; } = null!;

        [Required]
        public DateTime IssuedDate { get; set; }

        [Required]
        public string SignatureUrl { get; set; } = null!;

        public string? CourseName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        [Required]
        public Guid TrainingId { get; set; }
        public Training Training { get; set; } = null!;

        public List<UserCertificate> UserCertificates { get; set; } = new();
    }
}