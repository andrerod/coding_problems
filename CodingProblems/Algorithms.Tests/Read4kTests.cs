using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Tests
{

    [TestClass]
    public class Read4kTests
    {

        [TestMethod]
        public void Simple4k()
        {
            int[] buffer = new int[4096];
            Read4k reader = new Read4k(CreateFileData(4096));
            int readSize = reader.Read(buffer, 4096);
            VerifyFileData(buffer, readSize, 4096);
        }

        [TestMethod]
        public void SmallerThan4k()
        {
            int[] buffer = new int[4096];
            Read4k reader = new Read4k(CreateFileData(4000));
            int readSize = reader.Read(buffer, 4096);
            VerifyFileData(buffer, readSize, 4000);
        }

        [TestMethod]
        public void LargerThan4k()
        {
            int[] buffer = new int[4096];
            Read4k reader = new Read4k(CreateFileData(8192));
            int readSize = reader.Read(buffer, 4096);
            VerifyFileData(buffer, readSize, 4096);
        }

        [TestMethod]
        public void Simple8k()
        {
            int[] buffer = new int[8192];
            Read4k reader = new Read4k(CreateFileData(8192));
            int readSize = reader.Read(buffer, 8192);
            VerifyFileData(buffer, readSize, 8192);
        }

        [TestMethod]
        public void SmallerThan8k()
        {
            int[] buffer = new int[8192];
            Read4k reader = new Read4k(CreateFileData(8000));
            int readSize = reader.Read(buffer, 8192);
            VerifyFileData(buffer, readSize, 8000);
        }

        [TestMethod]
        public void LargerThan8k()
        {
            int[] buffer = new int[7000];
            Read4k reader = new Read4k(CreateFileData(10000));
            int readSize = reader.Read(buffer, 7000);
            VerifyFileData(buffer, readSize, 7000);
        }

        [TestMethod]
        public void ReadN4kMultiple()
        {
            int[] data = CreateFileData(4096);

            Read4k reader = new Read4k(data);
            int[] buffer = new int[1000];
            int readSize = reader.ReadN(buffer, 1000);
            VerifyFileData(buffer, readSize, 1000);

            int[] buffer2 = new int[1000];
            readSize = reader.ReadN(buffer2, 1000);
            VerifyFileDataContinuous(buffer2, 1000, readSize, 1000);

            int[] buffer3 = new int[1000];
            readSize = reader.ReadN(buffer3, 1000);
            VerifyFileDataContinuous(buffer3, 2000, readSize, 1000);

            int[] buffer4 = new int[1000];
            readSize = reader.ReadN(buffer4, 1000);
            VerifyFileDataContinuous(buffer4, 3000, readSize, 1000);
        }

        [TestMethod]
        public void ReadNOver4kMultiple()
        {
            int[] data = CreateFileData(4096);

            Read4k reader = new Read4k(data);
            int[] buffer = new int[4000];
            int readSize = reader.ReadN(buffer, 4000);
            VerifyFileData(buffer, readSize, 4000);

            int[] buffer2 = new int[1000];
            readSize = reader.ReadN(buffer2, 1000);
            VerifyFileDataContinuous(buffer2, 4000, readSize, 96);
        }

        private int[] CreateFileData(int size)
        {
            int[] buffer = new int[size];

            for (int index = 0; index < size; index++)
            {
                buffer[index] = index;
            }

            return buffer;
        }

        private void VerifyFileData(int[] fileData, int size, int expectedSize)
        {
            Assert.AreEqual(expectedSize, size);

            for (int index = 0; index < size; index++)
            {
                Assert.AreEqual(index, fileData[index]);
            }

            if (fileData.Length > size)
            {
                for (int index = size; index < fileData.Length; index++)
                {
                    Assert.AreEqual(0, fileData[index]);
                }
            }
        }

        private void VerifyFileDataContinuous(int[] fileData, int start, int size, int expectedSize)
        {
            Assert.AreEqual(expectedSize, size);

            for (int index = start; index < start + size; index++)
            {
                Assert.AreEqual(index, fileData[index - start]);
            }

            if (fileData.Length > size)
            {
                for (int index = size; index < fileData.Length; index++)
                {
                    Assert.AreEqual(0, fileData[index]);
                }
            }
        }

    }
}
