using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Tests
{

    [TestClass]
    public class IntegerPartitionTests
    {

        #region Partition

        [TestMethod]
        public void PartitionSimple()
        {
            var result = IntegerPartition.Partition(4);

            Assert.AreEqual(5, result.Count);

            Assert.AreEqual(4, result[0].Count);
            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(1, result[0][1]);
            Assert.AreEqual(1, result[0][2]);
            Assert.AreEqual(1, result[0][3]);

            Assert.AreEqual(3, result[1].Count);
            Assert.AreEqual(2, result[1][0]);
            Assert.AreEqual(1, result[1][1]);
            Assert.AreEqual(1, result[1][2]);

            Assert.AreEqual(2, result[2].Count);
            Assert.AreEqual(2, result[2][0]);
            Assert.AreEqual(2, result[2][1]);

            Assert.AreEqual(2, result[3].Count);
            Assert.AreEqual(3, result[3][0]);
            Assert.AreEqual(1, result[3][1]);

            Assert.AreEqual(1, result[4].Count);
            Assert.AreEqual(4, result[4][0]);
        }

        [TestMethod]
        public void PartitionDynamicProgramming()
        {
            var result = IntegerPartition.PartitionDynamicProgramming(4);

            Assert.AreEqual(5, result.Count);

            Assert.AreEqual(4, result[0].Count);
            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(1, result[0][1]);
            Assert.AreEqual(1, result[0][2]);
            Assert.AreEqual(1, result[0][3]);
            
            Assert.AreEqual(2, result[1].Count);
            Assert.AreEqual(2, result[1][0]);
            Assert.AreEqual(2, result[1][1]);

            Assert.AreEqual(3, result[2].Count);
            Assert.AreEqual(2, result[2][0]);
            Assert.AreEqual(1, result[2][1]);
            Assert.AreEqual(1, result[2][2]);

            Assert.AreEqual(2, result[3].Count);
            Assert.AreEqual(3, result[3][0]);
            Assert.AreEqual(1, result[3][1]);

            Assert.AreEqual(1, result[4].Count);
            Assert.AreEqual(4, result[4][0]);
        }

        #endregion

        #region CombinationSubSet

        [TestMethod]
        public void CombinationSubSetSimple()
        {
            var result = IntegerPartition.CombinationSubSet(new[] { 2, 3, 7 }, 10);

            Assert.AreEqual(3, result.Count);

            Assert.AreEqual(5, result[0].Count);
            Assert.AreEqual(2, result[0][0]);
            Assert.AreEqual(2, result[0][1]);
            Assert.AreEqual(2, result[0][2]);
            Assert.AreEqual(2, result[0][3]);
            Assert.AreEqual(2, result[0][4]);

            Assert.AreEqual(4, result[1].Count);
            Assert.AreEqual(3, result[1][0]);
            Assert.AreEqual(3, result[1][1]);
            Assert.AreEqual(2, result[1][2]);
            Assert.AreEqual(2, result[1][3]);

            Assert.AreEqual(2, result[2].Count);
            Assert.AreEqual(7, result[2][0]);
            Assert.AreEqual(3, result[2][1]);
        }

        [TestMethod]
        public void CombinationSubSetWrongOrder()
        {
            var result = IntegerPartition.CombinationSubSet(new[] { 2, 7, 3 }, 10);

            Assert.AreEqual(3, result.Count);
            
            Assert.AreEqual(5, result[0].Count);
            Assert.AreEqual(2, result[0][0]);
            Assert.AreEqual(2, result[0][1]);
            Assert.AreEqual(2, result[0][2]);
            Assert.AreEqual(2, result[0][3]);
            Assert.AreEqual(2, result[0][4]);

            Assert.AreEqual(2, result[1].Count);
            Assert.AreEqual(3, result[1][0]);
            Assert.AreEqual(7, result[1][1]);


            Assert.AreEqual(4, result[2].Count);
            Assert.AreEqual(3, result[2][0]);
            Assert.AreEqual(3, result[2][1]);
            Assert.AreEqual(2, result[2][2]);
            Assert.AreEqual(2, result[2][3]);
        }

        [TestMethod]
        public void CombinationSubSetDynamicProgramming()
        {
            var result = IntegerPartition.CombinationSubSetDynamicProgramming(new[] { 2, 3, 7 }, 10);

            Assert.AreEqual(3, result.Count);

            Assert.AreEqual(5, result[0].Count);
            Assert.AreEqual(2, result[0][0]);
            Assert.AreEqual(2, result[0][1]);
            Assert.AreEqual(2, result[0][2]);
            Assert.AreEqual(2, result[0][3]);
            Assert.AreEqual(2, result[0][4]);

            Assert.AreEqual(4, result[1].Count);
            Assert.AreEqual(3, result[1][0]);
            Assert.AreEqual(3, result[1][1]);
            Assert.AreEqual(2, result[1][2]);
            Assert.AreEqual(2, result[1][3]);

            Assert.AreEqual(2, result[2].Count);
            Assert.AreEqual(7, result[2][0]);
            Assert.AreEqual(3, result[2][1]);
        }

        #endregion

        #region Factors

        [TestMethod]
        public void FactorsSimple()
        {
            var result = IntegerPartition.GetFactorsRecursive(12);

            Assert.AreEqual(5, result.Count);

            Assert.AreEqual(2, result[0].Count);
            Assert.AreEqual(12, result[0][0]);
            Assert.AreEqual(1, result[0][1]);

            Assert.AreEqual(2, result[1].Count);
            Assert.AreEqual(2, result[1][0]);
            Assert.AreEqual(6, result[1][1]);

            Assert.AreEqual(3, result[2].Count);
            Assert.AreEqual(2, result[2][0]);
            Assert.AreEqual(2, result[2][1]);
            Assert.AreEqual(3, result[2][2]);

            Assert.AreEqual(2, result[3].Count);
            Assert.AreEqual(3, result[3][0]);
            Assert.AreEqual(4, result[3][1]);

            Assert.AreEqual(3, result[4].Count);
            Assert.AreEqual(3, result[4][0]);
            Assert.AreEqual(2, result[4][1]);
            Assert.AreEqual(2, result[4][2]);
        }

        #endregion

    }

}
