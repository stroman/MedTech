using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Globalization;

namespace MedTech.Application.Services.Membership
{
    public class SaltedHash
    {
        public string Hash { get; private set; }
        public string Salt { get; private set; }

        public SaltedHash(string password)
        {
            var saltBytes = new byte[32];
            new Random().NextBytes(saltBytes);
            Salt = Convert.ToBase64String(saltBytes);
            var passwordAndSaltBytes = Concat(password, saltBytes);
            Hash = ComputeHash(passwordAndSaltBytes);
        }

        static string ComputeHash(byte[] bytes)
        {
            using (var sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(bytes));
            }
        }

        static byte[] Concat(string password, byte[] saltBytes)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            return passwordBytes.Concat(saltBytes).ToArray();
        }

        public static bool Verify(string salt, string hash, string password)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var passwordAndSaltBytes = Concat(password, saltBytes);
            var hashAttempt = ComputeHash(passwordAndSaltBytes);
            return hash == hashAttempt;
        }

        public static string GetPassword()
        {
            var request = new Random();
            string randStr = request.NextDouble().ToString(CultureInfo.InvariantCulture);
            var bytes = Encoding.Unicode.GetBytes(randStr);
            var csp = new MD5CryptoServiceProvider();
            byte[] byteHash = csp.ComputeHash(bytes);
            return byteHash.Aggregate(string.Empty, (current, b) => current + string.Format("{0:x2}", b)).Substring(0, 8);
        }
    }
}
