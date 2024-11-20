// <copyright file="PasswordService.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Module.Services.Services
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Provides helper methods for hashing and verifying passwords using HMACSHA256.
    /// </summary>
    public class PasswordService
    {
        /// <summary>
        /// Hashes the provided password using HMACSHA256 and returns the hashed password and salt.
        /// </summary>
        /// <param name="password">The password to be hashed.</param>
        /// <returns>
        /// A tuple containing the hashed password as a string and the salt as a string.
        /// </returns>
        public (string PasswordHash, string PasswordSalt) HashPassword(string password)
        {
            using var hmac = new HMACSHA256();
            var salt = Convert.ToBase64String(hmac.Key);
            var hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return (hash, salt);
        }

        /// <summary>
        /// Verifies if the provided password matches the stored hash and salt.
        /// </summary>
        /// <param name="password">The password to verify.</param>
        /// <param name="storedHash">The stored hash to compare the password against.</param>
        /// <param name="storedSalt">The stored salt used for hashing the password.</param>
        /// <returns>
        /// True if the password matches the stored hash and salt; otherwise, false.
        /// </returns>
        public bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            using var hmac = new HMACSHA256(Convert.FromBase64String(storedSalt));
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return computedHash == storedHash;
        }
    }
}
