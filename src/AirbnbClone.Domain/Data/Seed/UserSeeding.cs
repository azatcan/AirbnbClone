using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace Airbnb.Domain.Data.Seed
{
    internal static class UserSeeding
    {
        internal static void SeedUser(this ModelBuilder builder)
        {
            //builder.Entity<User>().ToTable("Users");
            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = "system",
                UserName = "system",
                Email = "system@mail.com",
                PasswordHash = HashPassword("123456")
            };

            builder.Entity<User>().HasData(user);
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
