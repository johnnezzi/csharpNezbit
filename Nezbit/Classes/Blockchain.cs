using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Nezbit.Classes
{
    public class Blockchain
    {
        public static List<Block> chain;
        
        public Blockchain()
        {
            chain = new List<Block> {Block.Genesis()};
        }

        public void addBlock(string data)
        {
            Block block = Block.MineBlock(chain[^1], data);
            chain.Add(block);

        }
    }
}