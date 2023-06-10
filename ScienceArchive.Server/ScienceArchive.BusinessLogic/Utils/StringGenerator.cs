using System;
using System.Security.Cryptography;
using System.Text;

namespace ScienceArchive.BusinessLogic.Utils
{
    /// <summary>
    /// Generator of different strings
    /// </summary>
    public static class StringGenerator
    {
        /// <summary>
        /// Generate new salt. Primary for passwords
        /// </summary>
        /// <param name="size"></param>
        /// <returns>Salt for password</returns>
        /// <exception cref="Exception"></exception>
        public static string CreateSalt(int size = 64)
        {
            var byteSalt = RandomNumberGenerator.GetBytes(size);
            _ = byteSalt ?? throw new Exception("Cannot generate password salt");

            var salt = Convert.ToBase64String(byteSalt);
            _ = salt ?? throw new Exception("Cannot convert salt to string");

            return salt;
        }

        /// <summary>
        /// Generate hash from string value
        /// </summary>
        /// <param name="value">String value to create hash from</param>
        /// <returns>Hashed value</returns>
        public static string HashPassword(string password, string? salt = null)
        {
            salt = salt ?? CreateSalt();

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                Encoding.UTF8.GetBytes(salt),
                10000,
                HashAlgorithmName.SHA256,
                64
            );

            return Convert.ToBase64String(hash);
        }
    }
}

