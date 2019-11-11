﻿using System;
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

            for (var i = 1; i < chain.Count; i++)
            {
                Block block = chain[i];
                Block lastblock = chain[i - 1];

                if (block.PrintData("LastHash") != lastblock.PrintData("Hash") || block.PrintData("Hash") != Block.Hashdata(long.Parse(block.PrintData("Timestamp")) , block.PrintData("LastHash"), block.PrintData("Data"))) return false;
            }

            return true;
        }

        public void ReplaceChain(List<Block> NewChain)
        {
            if (NewChain.Count <= this.chain.Count)
            {
                Console.WriteLine("Received chain is not longer than the current chain");
                return;
            } else if (IsValidChain(NewChain) == false)
            {
                Console.WriteLine("This is not a valid Chain");
                return;
            }
            Console.WriteLine("Replacing BlockChain with current chain");
            this.chain = NewChain;
        }
        
    }
}