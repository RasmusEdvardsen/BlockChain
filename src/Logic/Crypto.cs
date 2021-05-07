using System.Text;
using System.Security.Cryptography;
using System;
using Common;

namespace Logic
{
    public static class Crypto
    {
        public static string GenerateHash(string data)
        {
            using var sha256 = SHA256.Create();

            byte[] hashedData = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));

            StringBuilder sBuilder = new();
            for (int i = 0; i < hashedData.Length; i++)
                sBuilder.Append(hashedData[i].ToString("x2"));

            return sBuilder.ToString();
        }

        public static string GenerateHash(string one, string two) => GenerateHash(one + two);

        public static Int64 HashToInt64(string hash)
        {
            if (string.IsNullOrEmpty(hash))
                return 0;

            using var sha256 = SHA256.Create();

            byte[] hashText = sha256.ComputeHash(Encoding.UTF8.GetBytes(hash));

            Int64 hashCodeStart = BitConverter.ToInt64(hashText, 0);
            Int64 hashCodeMedium = BitConverter.ToInt64(hashText, 8);
            Int64 hashCodeEnd = BitConverter.ToInt64(hashText, 24);

            return hashCodeStart ^ hashCodeMedium ^ hashCodeEnd;
        }

        
        public static string GeneratePublicKey(string secretKey)
        {
            var pubKey = (Crypto.HashToInt64(secretKey) * Constants.G) % Constants.N;
            return Crypto.GenerateHash(pubKey.ToString());
        }
    }
}
