using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingProblems;
using System.Linq;

namespace CodingProblemsTests
{
    [TestClass]
    public class Chapter1Tests
    {
        [TestMethod]
        public void Problem3Test1()
        {
            var inputStr = "Mr John Smith";
            var input = new char[inputStr.Length + 4];
            for(int i = 0; i < inputStr.Length; i++)
            {
                input[i] = inputStr[i];
            }

            Chapter1.Problem3(input, inputStr.Length);
            Assert.IsTrue(input.SequenceEqual("Mr%20John%20Smith"));
        }

        [TestMethod]
        public void Problem4Test1()
        {
            Assert.IsTrue(Chapter1.Problem4("tact coa"));
            Assert.IsTrue(Chapter1.Problem4("tacat"));
            Assert.IsTrue(Chapter1.Problem4("taat"));

            Assert.IsFalse(Chapter1.Problem4("tac"));
        }

        [TestMethod]
        public void Problem4ImprovedTest1()
        {
            Assert.IsTrue(Chapter1.Problem4Improved("tact coa"));
            Assert.IsTrue(Chapter1.Problem4Improved("tacat"));
            Assert.IsTrue(Chapter1.Problem4Improved("taat"));

            Assert.IsFalse(Chapter1.Problem4Improved("tac"));
        }

        [TestMethod]
        public void Problem5Test1()
        {
            Assert.IsTrue(Chapter1.Problem5("pale", "ple"));
            Assert.IsTrue(Chapter1.Problem5("pales", "pale"));
            Assert.IsTrue(Chapter1.Problem5("pale", "bale"));
            Assert.IsFalse(Chapter1.Problem5("pale", "bake"));
        }

        [TestMethod]
        public void Problem9Test1()
        {
            Assert.IsTrue(Chapter1.Problem9("waterbottle", "erbottlewat"));

            Assert.IsFalse(Chapter1.Problem9("waterbottle", "erbottlewa"));
        }
    }
}
