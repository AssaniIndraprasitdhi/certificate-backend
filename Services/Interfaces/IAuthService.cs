using CertificateAPI.Data;
using CertificateAPI.DTOs.User;

namespace CertificateAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserResponseDto> RegisterAsync(RegisterUserDto dto);
        Task<string> LoginAsync(LoginUserDto dto);
    }
}