using System.ComponentModel.DataAnnotations;

namespace CertificateAPI.DTOs.Certificate
{
    public class CertificateDto
    {
        [Required]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
       
    } 
}