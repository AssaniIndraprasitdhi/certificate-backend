using CertificateAPI.Data;
using CertificateAPI.DTOs.User;
using CertificateAPI.Helpers;
using CertificateAPI.Models;
using CertificateAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using DotNetEnv;

namespace CertificateAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;

        public AuthService(AppDbContext db)
        {
            _db = db;

            // Load .env once (ปลอดภัยแม้โหลดหลายรอบ)
            DotNetEnv.Env.Load();
        }

        public async Task<UserResponseDto> RegisterAsync(RegisterUserDto dto)
        {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Email is already registered.");

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                UserRoles = new List<UserRole>()
            };

            var role = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "USER");
            if (role != null)
            {
                user.UserRoles.Add(new UserRole { Role = role });
            }

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return new UserResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = new List<string> { "USER" }
            };
        }

        public async Task<string> LoginAsync(LoginUserDto dto)
        {
            var user = await _db.Users
                .Include(u => u.UserRoles!)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                throw new Exception("Invalid email or password.");

            var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
            var token = JwtHelper.GenerateToken(user.Id.ToString(), user.Email, roles);
            return token;
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
