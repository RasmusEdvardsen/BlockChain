using System.Text;
using System.Security.Cryptography;

namespace Logic
{
    public static class CustomHash
    {
        public static string Generate(string previousHash, string data)
        {
            using var sha256 = SHA256.Create();

            byte[] hashedData = sha256.ComputeHash(Encoding.UTF8.GetBytes(previousHash + data));

            StringBuilder sBuilder = new();
            for (int i = 0; i < hashedData.Length; i++)
                sBuilder.Append(hashedData[i].ToString("x2"));

            return sBuilder.ToString();
        }
    }
}
