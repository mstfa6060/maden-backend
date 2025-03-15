using System;
using System.Security.Cryptography;
using System.Text;

namespace BaseModules.IAM.Infrastructure.Security
{
    public static class SecurityHelper
    {
        // Rastgele bir salt oluşturur (32 bayt)
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // SHA256 ile şifreyi hashler
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Kullanıcının giriş yaptığı şifreyi hashleyip, DB'deki hash ile kıyaslar
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            string enteredHash = HashPassword(enteredPassword, storedSalt);
            return enteredHash == storedHash;
        }
    }
}
