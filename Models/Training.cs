using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertificateAPI.Models
{
    public class Training
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string TrainerName { get; set; } = string.Empty;
        public Guid CreateBy { get; set; }

        [ForeignKey("CreatedBy")]
        public User? Creator { get; set; }
    }
}