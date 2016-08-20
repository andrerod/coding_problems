using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Tests
{
   
    [TestClass]
    public class TrieTests
    {

        [TestMethod]
        public void SearchWordPosition()
        {
            var result = Trie.SearchWordPosition("us use uses used user users using useful username user utah".Split(' '), "user");

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(4, result[0]);
            Assert.AreEqual(9, result[1]);
        }

        [TestMethod]
        public void LongestCompoundWord()
        {
            var result = Trie.LongestCompoundWord(new string[] { "cat", "cats", "catsdogcats", "catxdogcatsrat", "dog", "dogcatsdog",
                "hippopotamuses", "rat", "ratcat", "ratcatdog", "ratcatdogcat" });

            Assert.AreEqual("ratcatdogcat", result);
        }

    }

}
