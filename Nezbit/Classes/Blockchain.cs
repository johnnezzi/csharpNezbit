using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Nezbit.Classes
{
    public class Blockchain
    {
        public List<Block> chain;

        public Blockchain()
        {
            chain = new List<Block> {Block.Genesis()};
        }

        public void addBlock(string data)
        {
            Block block = Block.MineBlock(chain[^1], data);
            chain.Add(block);

        }

        public Boolean IsValidChain(List<Block> chain)
        {
            if (chain[0].ToString() != Block.Genesis().ToString()) return false;

            for (var i = 0; i < chain.Count; i++)
            {
                Block block = chain[i];
                Block lastblock = chain[i - 1];

                if (block.PrintData("Hash") != "hello") return false;
            }

            return true;
        }
    }
}