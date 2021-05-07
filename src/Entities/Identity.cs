using System.Collections.Generic;
using Logic;

namespace Entities
{
    public class Identity
    {
        // should we even keep this?
        private string SecretKey { get; set; }

        // s = the secret key of the identity
        // g = some agreed upon arbitrary number
        // n = some agreed upon arbitrary number
        // (s * g) mod n
        public string PublicKey { get; set; }
        
        public Identity(List<string> passPhrase)
        {
            SecretKey = Crypto.GenerateHash(string.Join(" ", passPhrase));
            PublicKey = Crypto.GeneratePublicKey(SecretKey);
        }

        public bool Authenticate(List<string> passPhrase)
        {
            return SecretKey == Crypto.GenerateHash(string.Join(" ", passPhrase));
        }

        public override string ToString() => $"Public key: {PublicKey}";
    }
}