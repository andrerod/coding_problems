using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingProblemsTests
{
    [TestClass]
    public class LeetCodeTests
    {
        [TestMethod]
        public void Test()
        {
            var res = InterleavingString.IsInterleave("a", "b", "ab");
            Assert.IsTrue(res);
        }
    }
}
