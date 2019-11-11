using System;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Nezbit.Classes
{
    public class Block
    {
        private long Timestamp { get; set; }
        private string LastHash { get; set; }
        private string Hash { get; set; }
        private string Data { get; set; }

        public Block(long timestamp, string lasthash, string hash, string data)
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
                   $"Last Hash: {LastHash.Substring(0, 10)} " +
                   $"Hash     : {Hash.Substring(0, 10)} " +
                   $"Data     : {Data}";

        }
        
        public string PrintData(string data)
        {    
            switch (data)
            {
              case "Timestamp":
                  return Timestamp.ToString();
              case "LastHash":
                  return LastHash;
              case "Hash":
                  return Hash;
              case "Data":
                  return Data;
              default:
                  return "No valid data requested";
            }

        }
        
        public static Block Genesis()
        {
            return new Block(1234567890, "------------------", "f1r57-ha5h", "Genesis");
        }

        public static Block MineBlock(Block lastblock, String data)
        {
            long timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string lastHash = lastblock.Hash;
            string hash = Block.Hashdata(timestamp, lastHash, data);

            return new Block(timestamp, lastHash, hash, data);

        }

        public static string Hashdata(long timestamp, string lastHash, string data)
        {
            string rawData = $"{timestamp}+{lastHash}+{data}";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }

        }

    }
}