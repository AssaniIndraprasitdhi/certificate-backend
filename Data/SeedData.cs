using CertificateAPI.Models;

namespace CertificateAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { Name = "ADMIN" },
                    new Role { Name = "USER" }
                );

                context.SaveChanges();
            }
        }
    }
}