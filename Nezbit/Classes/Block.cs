using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Nezbit.Classes
{
    public class Block
    {
        private long Timestamp { get; set; }
        private string LastHash { get; set; }
        private string Hash { get; set; }
        private string Data { get; set; }
        
        public Block(long timestamp, string lasthash, string hash, string data )
        {
            Timestamp = timestamp;
            LastHash = lasthash;
            Hash = hash;
            Data = data;

        }

        public string PrintOut()
        {
            return "Block - " +
                   $"Timestamp: {Timestamp} " +
                   $"Last Hash: {LastHash.Substring(0,10)} " +
                   $"Hash     : {Hash.Substring(0,10)} " +
                   $"Data     : {Data}";

        }

        public static Block Genesis()
        {
            return new Block(1234567890, "------------------", "f1r57-ha5h", "blah blah blah");
        }

        public static Block MineBlock(Block Lastblock, String Data)
        {
            long timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string lastHash = Lastblock.Hash;
            string Hash = "to-do hash";

        }
    }
    
}