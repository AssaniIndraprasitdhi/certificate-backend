using System.ComponentModel.DataAnnotations;

namespace CertificateAPI.DTOs.Training
{
    public class TrainingDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string TrainerName { get; set; } = string.Empty;
    }
}