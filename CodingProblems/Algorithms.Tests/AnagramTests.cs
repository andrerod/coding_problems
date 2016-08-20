using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class AnagramTests
    {
        #region FindUsingSorting

        [TestMethod]
        public void EmptyListIfNull()
        {
            var anagram = new Anagram(null);

            var result = anagram.FindUsingSorting();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OneWord()
        {
            var anagram = new Anagram(new[] { "word" });

            var result = anagram.FindUsingSorting();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(1, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
        }

        [TestMethod]
        public void OneAnagram()
        {
            var anagram = new Anagram(new[] { "word", "drwo" });

            var result = anagram.FindUsingSorting();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(2, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
            Assert.AreEqual("drwo", result.ElementAt(0).ElementAt(1));
        }

        [TestMethod]
        public void OneAnagramAndOtherWord()
        {
            var anagram = new Anagram(new[] { "word", "drwo", "sdsad" });

            var result = anagram.FindUsingSorting();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(2, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
            Assert.AreEqual("drwo", result.ElementAt(0).ElementAt(1));
            Assert.AreEqual(1, result.ElementAt(1).Count());
            Assert.AreEqual("sdsad", result.ElementAt(1).ElementAt(0));
        }

        [TestMethod]
        public void OneAnagramMixedOrder()
        {
            var anagram = new Anagram(new[] { "word", "sdsad", "drwo" });

            var result = anagram.FindUsingSorting();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(2, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
            Assert.AreEqual("drwo", result.ElementAt(0).ElementAt(1));
            Assert.AreEqual(1, result.ElementAt(1).Count());
            Assert.AreEqual("sdsad", result.ElementAt(1).ElementAt(0));
        }

        [TestMethod]
        public void MultipleAnagram()
        {
            var anagram = new Anagram(new[] { "word", "wdro", "drwo" });

            var result = anagram.FindUsingSorting();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(3, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
            Assert.AreEqual("wdro", result.ElementAt(0).ElementAt(1));
            Assert.AreEqual("drwo", result.ElementAt(0).ElementAt(2));
        }

        #endregion

        #region FindUsingPrimeNumberHashing

        [TestMethod]
        public void FindUsingPrimeNumberHashingEmptyListIfNull()
        {
            var anagram = new Anagram(null);

            var result = anagram.FindUsingPrimeNumberHashing();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void FindUsingPrimeNumberHashingOneWord()
        {
            var anagram = new Anagram(new[] { "word" });

            var result = anagram.FindUsingPrimeNumberHashing();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(1, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
        }

        [TestMethod]
        public void FindUsingPrimeNumberHashingOneAnagram()
        {
            var anagram = new Anagram(new[] { "word", "drwo" });

            var result = anagram.FindUsingPrimeNumberHashing();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(2, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
            Assert.AreEqual("drwo", result.ElementAt(0).ElementAt(1));
        }

        [TestMethod]
        public void FindUsingPrimeNumberHashingOneAnagramAndOtherWord()
        {
            var anagram = new Anagram(new[] { "word", "drwo", "sdsad" });

            var result = anagram.FindUsingPrimeNumberHashing();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(2, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
            Assert.AreEqual("drwo", result.ElementAt(0).ElementAt(1));
            Assert.AreEqual(1, result.ElementAt(1).Count());
            Assert.AreEqual("sdsad", result.ElementAt(1).ElementAt(0));
        }

        [TestMethod]
        public void FindUsingPrimeNumberHashingOneAnagramMixedOrder()
        {
            var anagram = new Anagram(new[] { "word", "sdsad", "drwo" });

            var result = anagram.FindUsingPrimeNumberHashing();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(2, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
            Assert.AreEqual("drwo", result.ElementAt(0).ElementAt(1));
            Assert.AreEqual(1, result.ElementAt(1).Count());
            Assert.AreEqual("sdsad", result.ElementAt(1).ElementAt(0));
        }

        [TestMethod]
        public void FindUsingPrimeNumberHashingMultipleAnagram()
        {
            var anagram = new Anagram(new[] { "word", "wdro", "drwo" });

            var result = anagram.FindUsingPrimeNumberHashing();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(3, result.ElementAt(0).Count());
            Assert.AreEqual("word", result.ElementAt(0).ElementAt(0));
            Assert.AreEqual("wdro", result.ElementAt(0).ElementAt(1));
            Assert.AreEqual("drwo", result.ElementAt(0).ElementAt(2));
        }

        #endregion
    }
}
