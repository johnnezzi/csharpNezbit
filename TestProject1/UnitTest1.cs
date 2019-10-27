using System;
using Nezbit.Classes;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {   
            Block testBlock = new Block(20140112180244, "lasthashexample", "012345678912345", "dataexample");
            
            Assert.That(testBlock.PrintOut(), Is.EqualTo("Block - Timestamp: 20140112180244 Last Hash: lasthashex Hash     : 0123456789 Data     : dataexample"));
            Console.WriteLine(testBlock.PrintOut());
        }
        [Test]
        public void Test2()
        {
            Block testGenesis = Block.Genesis();
            
            Assert.That(testGenesis.PrintOut(), Is.EqualTo("Block - Timestamp: 1234567890 Last Hash: ---------- Hash     : f1r57-ha5h Data     : blah blah blah"));
        }
    }
}