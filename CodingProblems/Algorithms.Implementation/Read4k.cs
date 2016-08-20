using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    public class Read4k
    {
        //given an api which can read 4k (or less) each time it is called, implement
        //int read(char[] buffer, int size)
        //could be called again and again

        private int currentOffset;
        private int currentReadOffset;
        private int[] fileData;
        private int[] leftOverFileData;

        public Read4k(int[] fileData)
        {
            this.fileData = fileData;
            this.currentOffset = 0;
            this.currentReadOffset = 0;
            this.leftOverFileData = new int[4096];
        }

        public int Read(int[] buffer, int size)
        {
            int readSize = 0; 
            int readSize4k = 4096;

            while ((size > readSize) && (readSize4k == 4096))
            {
                int[] tempBuffer = new int[4096];
                readSize4k = this.Read4K(tempBuffer);

                int sizeToCopy = System.Math.Min(readSize + readSize4k, size);
                for (int index = readSize; index < sizeToCopy; index++)
                {
                    buffer[index] = tempBuffer[index - readSize];
                }
                readSize = sizeToCopy;
            }

            return readSize;
        }

        //similar to 4k this will read next size...remembering the offset
        public int ReadN(int[] buffer, int size)
        {
            int readSize = System.Math.Min(this.currentReadOffset, size);
            int readSize4k = 4096;

            //put left over first
            for (int index = 0; index < readSize; index++)
            {
                buffer[index] = this.leftOverFileData[index];
            }

            //if we read less than what's left over, need to remove those
            if (readSize < this.currentReadOffset)
            {
                for (int index = readSize; index < this.currentReadOffset; index++)
                {
                    this.leftOverFileData[index - readSize] = this.leftOverFileData[index];
                }
                this.currentReadOffset -= readSize;
            }

            while ((size > readSize) && (readSize4k == 4096))
            {
                int[] tempBuffer = new int[4096];
                readSize4k = this.Read4K(tempBuffer);

                for (int index = readSize; index < readSize + readSize4k; index++)
                {
                    if (index < size)
                    {
                        buffer[index] = tempBuffer[index - readSize];
                    }
                    else
                    {
                        leftOverFileData[index - size] = tempBuffer[index - readSize];
                    }
                }
                this.currentReadOffset = System.Math.Max(readSize + readSize4k - size, 0);
                readSize = System.Math.Min(readSize + readSize4k, size);
            }

            return readSize;
        }

        private int Read4K(int[] buffer)
        {
            int indexToRead = System.Math.Min(currentOffset + 4096, fileData.Length);
            for (int index = currentOffset; index < indexToRead; index++)
            {
                buffer[index - currentOffset] = fileData[index];
            }
            int readSize = indexToRead - currentOffset;
            currentOffset = indexToRead;
            return readSize;
        }
    }
}
