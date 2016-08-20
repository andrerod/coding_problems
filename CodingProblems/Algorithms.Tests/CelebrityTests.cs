using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Tests
{

    [TestClass]
    public class CelebrityTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoCelebrity()
        {
            Celebrity.Find(new bool[3, 3] { 
                { false, true, false },
                { true, false, true },
                { true, true, false }
            });
        }

        [TestMethod]
        public void Valid()
        {
            Assert.AreEqual(2, Celebrity.Find(new bool[4, 4] { 
                { false, true, true, false },
                { true, false, true, true },
                { false, false, false, false },
                { true, true, true, false }
            }));
        }

    }

}
