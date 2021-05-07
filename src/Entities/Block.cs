using Logic;

namespace Entities
{
    internal class Block
    {
        public string Hash { get; set; }
        public string Data { get; set; }
        public string PreviousHash { get; set; }

        public Block(string data, string previousHash)
        {
            Data = data;
            PreviousHash = previousHash;
            Hash = GenerateHash();
        }

        public string GenerateHash() => Crypto.GenerateHash(PreviousHash, Data);
        
        public override string ToString() => $"Block hash: {Hash}\nBlock data: {Data}";
    }
}