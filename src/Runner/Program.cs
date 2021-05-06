using System;
using Entities;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockChain blockChain = new();
            blockChain.AddBlock("Second block");
            System.Console.WriteLine(blockChain.Validate());
        }
    }
}
