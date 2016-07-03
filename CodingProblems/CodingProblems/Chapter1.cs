using System.Collections.Generic;

namespace CodingProblems
{
    public class Chapter1
    {
        public static void Problem3(char[] input, int size)
        {
            // count spaces
            int numSpaces = 0;
            for (int i = 0; i < size; i++)
            {
                if (input[i] == ' ')
                {
                    numSpaces++;
                }
            }

            // shift letters
            var newPos = size + (numSpaces * 2) - 1;
            for (int i = size - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    input[newPos - 2] = '%';
                    input[newPos - 1] = '2';
                    input[newPos] = '0';
                    newPos -= 3;
                }
                else
                {
                    input[newPos] = input[i];
                    newPos--;
                }
            }
        }

        public static bool Problem4(string input)
        {
            var letters = new Dictionary<char, int>();
            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    letters[letter] = letters.ContainsKey(letter)
                        ? letters[letter] + 1
                        : 1;
                }
            }

            int notEven = 0;
            foreach (var letterCount in letters.Values)
            {
                if (letterCount % 2 > 0)
                {
                    if (notEven > 0)
                    {
                        return false;
                    }
                    else
                    {
                        notEven++;
                    }
                }
            }

            return true;
        }

        public static bool Problem4Improved(string input)
        {
            var bitArray = CreateBitVector(input);
            return (bitArray & (bitArray - 1)) == 0;
        }

        private static int CreateBitVector(string input)
        {
            var bitArray = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var number = GetCharNumber(input[i]);
                if (number != -1)
                {
                    bitArray = Toggle(bitArray, number);
                }
            }

            return bitArray;
        }

        private static int Toggle(int bitArray, int charNumber)
        {
            var mask = 1 << charNumber;
            return bitArray ^ mask;
        }

        private static int GetCharNumber(char letter)
        {
            int a = 'a';
            int z = 'z';

            if (a <= letter && z >= letter)
            {
                return letter - a;
            }

            return -1;
        }

        public static bool Problem5(string input1, string input2)
        {
            // S1 shorter, S2 longer
            string s1 = input1.Length < input2.Length ? input1 : input2;
            string s2 = input1.Length < input2.Length ? input2 : input1;

            bool foundDifference = false;
            int index1 = 0;
            int index2 = 0;

            while (index1 < input1.Length && index2 < input2.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (foundDifference)
                    {
                        return false;
                    }

                    foundDifference = true;

                    if (s1.Length == s2.Length)
                    {
                        index1++;
                    }
                }
                else
                {
                    index1++;
                }

                index2++;
            }

            return true;
        }

        public static bool Problem9(string s1, string s2)
        {
            if (s1.Length == s2.Length)
            {
                var s1s1 = s1 + s1;
                return s1s1.IndexOf(s2) >= 0;
            }

            return false;
        }

        public static void Problem8(int[][] matrix)
        {
            bool nullFirstColumn = false;
            bool nullFirstRow = false;

            for (int i = 0; i < matrix.Length && !nullFirstColumn; i++)
            {
                if (matrix[i][0] == 0)
                {
                    nullFirstColumn = true;
                }
            }

            for (int i = 0; i < matrix[0].Length && !nullFirstRow; i++)
            {
                if (matrix[0][i] == 0)
                {
                    nullFirstRow = true;
                }
            }

            // Find 0s
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            // nullify based on column values
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // nullify based on row values
            for (int i = 0; i < matrix[0].Length; i++)
            {
                if (matrix[0][i] == 0)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        matrix[j][i] = 0;
                    }
                }
            }

            if (nullFirstColumn)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }

            if (nullFirstRow)
            {
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    matrix[0][i] = 0;
                }
            }
        }
    }
}
