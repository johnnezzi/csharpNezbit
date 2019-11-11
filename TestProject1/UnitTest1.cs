using System;
using System.Collections.Generic;
using Nezbit.Classes;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PrintsOutCorrectInfo()
        {   
            Block testBlock = new Block(20140112180244, "lasthashexample", "012345678912345", "dataexample");
            
            Assert.That(testBlock.PrintOut(), Is.EqualTo("Block - Timestamp: 20140112180244 Last Hash: lasthashex Hash     : 0123456789 Data     : dataexample"));
            Console.WriteLine(testBlock.PrintOut());
        }
        [Test]
        public void PrintsOutCorrectInfoGenesis()
        {
            Block testGenesis = Block.Genesis();
            
            Assert.That(testGenesis.PrintOut(), Is.EqualTo("Block - Timestamp: 1234567890 Last Hash: ---------- Hash     : f1r57-ha5h Data     : Genesis"));
        }

        [Test]

        public void MinesBlockwithCorrectData()
        {
            string data = "foo";
            Block lastBlock = Block.Genesis();
            Block block = Block.MineBlock(lastBlock, data);

            Assert.That(block.PrintData("Data"), Is.EqualTo(data));
            //sets the data to match the input
        }
        
        [Test]
        public static void ChainStartsWithGenesis()
        {
            Blockchain bc = new Blockchain(); 
                    
            Assert.That(bc.chain[0].PrintData("Data"), Is.EqualTo("Genesis"));
        }
       [Test] 
        public static void ChainAddsBlock()
        {
            Blockchain bc = new Blockchain();
            string data = "bar";
            bc.addBlock(data);
           
            Assert.That(bc.chain[^1].PrintData("Data"), Is.EqualTo("bar"));
        }
        
        [Test]
        public static void ValidatesAValidChain()
        {
            Blockchain bc = new Blockchain();
            Blockchain bc2 = new Blockchain();
            
            bc2.addBlock("foo");
            
            Assert.That(bc.IsValidChain(bc2.chain), Is.True);
            
        }
        
        [Test]

        public static void ReplacesBlockChainWithValidChain()
        {   
            Blockchain bc = new Blockchain();
            Blockchain bc2 = new Blockchain();
            bc2.addBlock("goo");
            bc.ReplaceChain(bc2.chain);

            Assert.That(bc.chain, Is.EquivalentTo(bc2.chain));
        }
        [Test]
        public static void ReplacesBlockChainWithInValidChain()
        {   
            Blockchain bc = new Blockchain();
            Blockchain bc2 = new Blockchain();
            bc.addBlock("goo");
            bc.ReplaceChain(bc2.chain);

            Assert.That(bc.chain, Is.Not.EquivalentTo(bc2.chain));
        }
    }
        
}