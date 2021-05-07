using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Logic;

namespace Entities
{
    public class BlockChain
    {
        private List<Block> Blocks = new List<Block> { new("Genesis", null) };

        public BlockChain() { }

        public void AddBlock(string data)
        {
            Blocks.Add(new(data, Blocks.Last().Hash));
        }

        public bool Validate()
        {
            return Blocks.All(block => block.GenerateHash() == block.Hash);
        }

        public override string ToString()
        {
            return string.Join("\n", Blocks.Select((b, i) => $"Block #{i}: {b.Hash}"));
        }
    }
}