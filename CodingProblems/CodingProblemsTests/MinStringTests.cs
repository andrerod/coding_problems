using CodingProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodingProblemsTests
{
    [TestClass]
    public class MinStringTests
    {
        [TestMethod]
        public void Works()
        {
            /*
            Input string1: "this is a test string"
Input string2: "tist"
Output string: "t stri" */

            var output = MinString.MinSubstring("this is a test string", "tist");

            Assert.AreEqual("t stri", output);
        }

        [TestMethod]
        public void TestDictionary()
        {
            var test = new Dictionary<string, int>();
            test["foo"] = 0;
            test["foo"]++;

            Assert.AreEqual(1, test["foo"]);
        }
    }
}
