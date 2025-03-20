﻿using System.Security.Cryptography;
using System.Text;

namespace FreelancePlatform.Services.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            var hashOfInput = HashPassword(inputPassword);
            return hashOfInput == hashedPassword;
        }
    }
}
