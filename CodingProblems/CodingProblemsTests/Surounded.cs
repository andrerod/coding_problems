using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingProblemsTests
{
    [TestClass]
    public class Surounded
    {
        [TestMethod]
        public void TestProblem1a()
        {
            var board = new[,] { { 'O', 'O', 'O' }, { 'O', 'O', 'O' } , { 'O', 'O', 'O' } };

            SuroundedRegions.Solution.Solve(board);

            var i = 0;
        }
    }
}
