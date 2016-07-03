using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingProblems;
using System.Linq;

namespace CodingProblemsTests
{
    [TestClass]
    public class Chapter5Tests
    {
        [TestMethod]
        public void SwapRequiredTest1()
        {
            Assert.AreEqual(1, Chapter5.SwapRequired(1, 3));
            Assert.AreEqual(2, Chapter5.SwapRequired(5, 3));
            Assert.AreEqual(0, Chapter5.SwapRequired(3, 3));
        }
    }
}
