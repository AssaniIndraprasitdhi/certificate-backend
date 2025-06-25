using System.ComponentModel.DataAnnotations;

namespace CertificateAPI.DTOs.User
{
    public class LoginUserDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}