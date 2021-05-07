namespace Entities
{
    internal class Transaction
    {
        // s = the secret key of the identity issuing the transaction
        // m = some agreed upon combination of data from transaction
        // n = some agreed upon arbitrary number
        // (s * m) mod n
        public string Signature { get; set; }
    }
}