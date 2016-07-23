using CodingProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingProblemsTests
{
    [TestClass]
    public class Chapter17Tests
    {
        [TestMethod]
        public void SearchAllTests()
        {
            var res = Chapter17.SearchAll("mississippi", new[] { "is", "ppi", "hi", "sis", "i", "ssippi" });

            Assert.IsNotNull(res);
        }
    }
}
