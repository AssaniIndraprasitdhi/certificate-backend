namespace CertificateAPI.DTOs.User
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string FullName => "${FirstName} {LastName}";
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();
    }
}