namespace Entities
{
    internal class Transaction
    {
        // pubKey = the public key of the identity issuing the transaction
        // m = some agreed upon combination of data from transaction
        // n = some agreed upon arbitrary number
        // (pubKey * m) mod n
        public string Signature { get; set; }
    }
}