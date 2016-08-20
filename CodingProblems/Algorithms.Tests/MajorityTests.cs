using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Tests
{
    
    [TestClass]
    public class MajorityTests
    {

        [TestMethod]
        public void TestMajority()
        {
            string characters = "AAABBAABBCCDDAAAA";

            Assert.AreEqual('A', Majority.FindMajority(characters.ToArray()).Value);
        }

        [TestMethod]
        public void TestMajorityFalse()
        {
            string characters = "AAABBAABBCCDDEEFF";

            Assert.IsNull(Majority.FindMajority(characters.ToArray()));
        }

        [TestMethod]
        public void TestMajorityComplex()
        {
            string characters = "AAABBBCCC";

            Assert.IsNull(Majority.FindMajority(characters.ToArray()));
        }

    }

}
