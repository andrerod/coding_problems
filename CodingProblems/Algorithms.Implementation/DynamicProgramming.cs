using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    
    public class DynamicProgramming
    {

        /*
         Sub problems for String/Sequence

	        Suffix (n)
	        Prefix (n)

            Substring (n^2)
         
         */
         
         
        #region Knapsack

        /// <summary>
        /// 0 - 1 knapsack where the item can be included or not included
        /// <image url="$(SolutionDir)\Images\knapsack.png" />
        /// </summary>
        /// <param name="total"></param>
        /// <param name="weights"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int Knapsack(int capacity, int[] weights, int[] values, List<int> choices)
        {
            int[,] Value = new int[weights.Length + 1, capacity + 1];

            for (int item = 0; item <= weights.Length; item++)
            {
                for (int space = 0; space <= capacity; space++)
                {
                    if ((item == 0) || (space == 0))
                    {
                        //initialize
                        Value[item, space] = 0;
                        continue;
                    }

                    int currentWeight = weights[item - 1];
                    int currentValue = values[item - 1];

                    if (currentWeight <= space)
                    {
                        //now this item may be valid since it's smaller than available space
                        //cost is max of the following
                        //either we take current item or we do not take the current item
                        //  taking current item - max of all previous items minus current weight + current value 
                        //      Value[item - 1, space - currentWeight] + currentValue
                        //  not taking current item - max of all previous items with full weight
                        //      Value[item - 1, space]
                        Value[item, space] = System.Math.Max(Value[item - 1, space - currentWeight] + currentValue, Value[item - 1, space]);
                    }
                    else
                    {
                        //this item is not valid...keep the last one
                        Value[item, space] = Value[item - 1, space];
                    }
                }
            }

            int weight = capacity;
            for (int item = weights.Length; item > 0; item--)
            {
                if (Value[item, weight] != Value[item - 1, weight])
                {
                    //if the value here is equal to the previous item's max, that means i did not take this item
                    //if they are not equal, that means i took this item
                    choices.Add(weights[item - 1]);
                }
            }

            return Value[weights.Length, capacity];
        }

        #endregion

        #region Edit Distance
        
        /// <summary>
        /// +1 for delete, insertion and substitution
        /// e.g. Saturday & Sunday has 3
        /// S a(i) t(i) u r(n -> r) day
        /// 
        /// Complexity 3^min(n,m)
        /// </summary>
        /// <param name="string1"></param>
        /// <param name="string2"></param>
        /// <returns></returns>
        public static int EditDistanceRecursive(string string1, string string2)
        {
            return EditDistanceRecursive(string1, string2, string1.Length, string2.Length);
        }

        private static int EditDistanceRecursive(string string1, string string2, int length1, int length2)
        {
            // if one is shorter, then we need to make as many changes as the other string
            if (length1 == 0)
            {
                return length2;
            }
            if (length2 == 0)
            {
                return length1;
            }

            //now we have three cases
            //cost of current letter which could be 0 or 1 and added with cost of all previous letters (abcd <> abce)
            //cost of removing one letter (abcd <> abc)
            //cost of adding one letter (abc <> abcd)
            //then we just have to recursively do this for each length
            return System.Math.Min(System.Math.Min(
                EditDistanceRecursive(string1, string2, length1 - 1, length2 - 1) + ((string1[length1 - 1] == string2[length2 - 1]) ? 0 : 1),
                EditDistanceRecursive(string1, string2, length1 - 1, length2) + 1), //since we removed one, we have to take the cost
                EditDistanceRecursive(string1, string2, length1, length2 - 1) + 1 //this is same as adding one to string 1
            );
        }

        /// <summary>
        ///             S   A   T   U   R   D   A   Y
        ///         0   1   2   3   4   5   6   7   8   
        ///     S   1   0   1   2   3   4   5   6   7
        ///     U   2   1   1   2   2   3   4   5   6
        ///     N   3   2   2   2   3   3   4   5   6
        ///     D   4   3   3   3   3   4   3   4   5
        ///     A   5   4   3   4   4   4   4   3   4
        ///     Y   6   5   4   4   5   5   5   4   3
        /// </summary>
        /// <param name="string1"></param>
        /// <param name="string2"></param>
        /// <returns></returns>
        public static int EditDistanceDynamicProgramming(string string1, string string2)
        {
            int[,] distance = new int[string1.Length + 1, string2.Length + 1];

            //base case
            //for all length of 0, edit distance is equal to length of the other string
            for (int count = 1; count <= string1.Length; count++)
            {
                distance[count, 0] = count;
            }
            for (int count = 1; count <= string2.Length; count++)
            {
                distance[0, count] = count;
            }

            //build bottom up use the same logic as recursive method
            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    distance[i, j] = System.Math.Min(System.Math.Min(
                        distance[i - 1, j - 1] + (string1[i - 1] == string2[j - 1] ? 0 : 1),
                        distance[i - 1, j] + 1),
                        distance[i, j - 1] + 1);
                }
            }

            return distance[string1.Length, string2.Length];
        }

        #endregion

        #region Longest Subsequence

        /// <summary>
        /// Not common substring which has to be consecutive
        /// Given two strings like BANANA & ATANA answer is AANA and there are 3 cases
        ///     If last characters are the same, then we can remove and continue comparing
        ///            BANAN, ATAN => BANA, ATA => BAN, AT and come up with ANA
        ///     If last characters are different then try variation by removing last character
        ///         BAN, AT => BA, AT => BA, A and come up with A
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static string LongestSubstringRecursive(string s1, string s2)
        {
            return LongestSubstringRecursive(s1, s2, s1.Length, s2.Length);
        }

        private static string LongestSubstringRecursive(string s1, string s2, int length1, int length2)
        {
            StringBuilder subsequence = new StringBuilder();

            if ((length1 == 0) || (length2 == 0))
            {
                return string.Empty;
            }

            if (s1[length1 - 1] == s2[length2 - 1])
            {
                subsequence.Append(LongestSubstringRecursive(s1, s2, length1 - 1, length2 - 1));
                subsequence.Append(s1[length1 - 1]);
            }
            else
            {
                string subsequence1 = LongestSubstringRecursive(s1, s2, length1 - 1, length2);
                string subsequence2 = LongestSubstringRecursive(s1, s2, length1, length2 - 1);

                subsequence.Insert(0, (subsequence1.Length > subsequence2.Length) ? subsequence1 : subsequence2);
            }

            return subsequence.ToString();
        }

        /// <summary>
        ///             B       A       N       A       N       A
        ///             ""      ""      ""      ""      ""      ""
        /// A      ""   ""      A       A       A       A       A
        /// T      ""   ""      A       A       A       A       A
        /// A      ""   ""      A       A       AA      AA      AA
        /// N      ""   ""      A      AN      AN/AA    AAN     AAN
        /// A      ""   ""      A      AN       ANA    ANA/AAN  AANA
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static string LongestSubstringDynamic(string s1, string s2)
        {
            string[,] matrix = new string[s1.Length + 1, s2.Length + 1];

            for (int i1 = 0; i1 <= s1.Length; i1++)
            {
                for (int i2 = 0; i2 <= s2.Length; i2++)
                {
                    if ((i1 == 0) || (i2 == 0))
                    {
                        matrix[i1, i2] = string.Empty;
                        continue;
                    }

                    if (s1[i1 - 1] == s2[i2 - 1]) {
                        matrix[i1, i2] = matrix[i1 - 1, i2 - 1] + s1[i1 - 1];
                    }
                    else {
                        string substring1 = matrix[i1 - 1, i2];
                        string substring2 = matrix[i1, i2 - 1];
                        
                        matrix[i1, i2] = ((substring1.Length > substring2.Length) ? substring1 : substring2);
                    }
                }
            }

            return matrix[s1.Length, s2.Length];
        }

        #endregion

        #region Matrix Traverse

        /// <summary>
        /// A robot has to move in a grid which is in the form of a matrix. It can go to
        /// 1.) A(i,j)--> A(i+j,j) (Right)
        /// 2.) A(i,j)--> A(i,i+j) (Down)
        /// 
        /// Given it starts at (1,1) and it has to go to A(m,n), find the minimum number of STEPS it has to take to get to (m,n) and write
        /// public static int minSteps(int m,int n)
        /// 
        /// For instance to go from (1,1) to m=3 and n=2 it has to take (1, 1) -> (1, 2) -> (3, 2) i.e. 2 steps
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int TraverseMatrix(int m, int n)
        {
            if ((m == 1) && (n == 1)) {
                return 0;
            }

            if ((m < 1) || (n < 1))
            {
                //error case
                throw new ArgumentException();
                //try 3, 3...there is no way.
            }

            if (m < n)
            {
                //if m is smaller we can only go n - m
                return 1 + TraverseMatrix(m, n - m);
            }
            else
            {
                return 1 + TraverseMatrix(m - n, n);
            }
        }

        #endregion

        #region Discontinuous String

        /// <summary>
        /// Given two strings, find number of discontinuous matches.
        /// “cat”, “catapult”
        /// 
        /// 3 => “CATapult”, “CatApulT”, “CAtapulT”
        /// 
        /// Seems like i can do this, for each substring of the longer word, pass shorter string to see if i find a match
        /// If the character matches, pass substrings of both to see if there is a further match
        /// If shorter word has just one character left, then do contains and increment a count
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static int DiscontinuousStringRecursive(string s1, string s2)
        {
            if (s1.Length == 1)
            {
                return (s2.Contains(s1[0])) ? 1 : 0;
            }

            if (s2.Length == 1)
            {
                return 0;
            }

            int count = 0;

            if (s1[s1.Length - 1] == s2[s2.Length - 1])
            {
                count += DiscontinuousStringRecursive(s1.Substring(0, s1.Length - 1), s2.Substring(0, s2.Length - 1));
            }

            if (s2.Length > s1.Length)
            {
                count += DiscontinuousStringRecursive(s1, s2.Substring(0, s2.Length - 1));
            }

            return count;
        }

        /// <summary>
        ///         j   C   A   T   A   P   U   L   T
        ///      i  0   0   0   0   0   0   0   0   0 
        ///      C  0   1   1   1   1   1   1   1   1   
        ///      A  0   0   1   1   2   2   2   2   2
        ///      T  0   0   0   1   1   1   1   1   3
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static int DiscontinuousStringDynamic(string s1, string s2)
        {
            int[,] matrix = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if ((i == 0) || (j == 0))
                    {
                        matrix[i, j] = 0;
                        continue;
                    }

                    if (i == 1)
                    {
                        matrix[i, j] = s2.Substring(0, j).Contains(s1[i - 1]) ? 1 : 0;
                        continue;
                    }

                    int count = 0;
                    if (s1[i - 1] == s2[j - 1])
                    {
                        count += matrix[i - 1, j - 1];
                    }

                    if (j > i)
                    {
                        count += matrix[i, j - 1];
                    }

                    matrix[i, j] = count;
                }
            }

            return matrix[s1.Length, s2.Length];
        }

        #endregion

        #region Raggedness of line

        /// <summary>
        /// Given the jaggedness as sum of squares of trailing spaces, find the optimal line breaks to reduce
        /// jaggedness
        /// 
        /// column size of 6
        /// aaa bb
        /// cc
        /// ddddd
        /// 
        /// or 
        /// 
        /// aaa
        /// bb cc
        /// ddddd
        /// 
        /// Seems like a simple DP problem
        /// 
        /// Sub problems (think brute force)
        /// 
        ///     Brute force
        ///         For each word, does it begin a new line (2^n complexity)
        ///     
        ///     Suffixes words
        ///         If I put a line break, what's left (n)
        /// 
        /// Guess (DP(i))
        ///     Where to start the next line
        ///     
        ///     for j in range (i +  1, n)
        /// 
        /// Min of
        ///     DP(j) + cost(ij)
        ///     for j in range (i +  1, n)
        ///     
        /// 
        ///         j   aaa     bb      cc          ddddd
        ///  i
        ///  aaa        3^2     0       -1          -1
        ///  bb                 4^2     1^2         -1
        ///  cc                         4^2         -1
        ///  ddddd                                  1^2
        ///  
        ///         j       I       would   like    to      be      wrapped     into    three   lines
        ///  i
        ///  I              14^2    8^2     3^2     0       -1      -1          -1      -1      -1
        ///  would                  10^2    5^2     2^2     -1      -1          -1      -1      -1
        ///  like                           11^2    8^2     5^2     -1          -1      -1      -1
        ///  to                                     13^2    10^2    2^2         -1      -1      -1
        ///  be                                             13^2    5^2         0       -1      -1
        ///  wrapped                                                8^2         3^2     -1      -1
        ///  into                                                               11^2    5^2     -1
        ///  three                                                                      10^2    4^2
        ///  lines                                                                              10^2
        /// </summary>
        /// <param name="words"></param>
        /// <param name="columnSize"></param>
        /// <returns></returns>
        public static List<string> ReduceRaggedness(string[] words, int columnSize)
        {
            int[,] spaces = new int[words.Length, words.Length];

            List<int> breakIndexes = new List<int>();

            for (int i = 0; i < words.Length; i++)
            {
                spaces[i, i] = columnSize - words[i].Length;
                for (int j = i + 1; j < words.Length; j++)
                {
                    //-1 for extra space between words
                    spaces[i, j] = spaces[i, j - 1] - words[j].Length - 1;
                }
            }

            int[] breakIndex = new int[words.Length + 1];
            int[] minCost = new int[words.Length + 1];
            for (int j = 1; j <= words.Length; j++)
            {
                minCost[j] = int.MaxValue;
            }
            for (int j = 1; j <= words.Length; j++)
            {
                for (int i = 1; i <= j; i++)
                {
                    int cost = (spaces[i - 1, j - 1] < 0) ? int.MaxValue : (minCost[i - 1] + (int)System.Math.Pow(spaces[i - 1, j - 1], 2));
                    if (minCost[j] > cost)
                    {
                        minCost[j] = cost;
                        breakIndex[j] = i;
                    }
                }
            }

            List<string> result = new List<string>();
            int endWord = words.Length;
            while (endWord > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = breakIndex[endWord] - 1; i < endWord; i++)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(words[i]);
                }
                endWord = breakIndex[endWord] - 1;
                result.Insert(0, sb.ToString());
            }
            return result;
        }

        #endregion

        #region All Palindromes

        /// <summary>
        /// Find all palindrome greater than length 2
        /// This is very similar to technique for longest palindrome
        /// 
        /// abaabccba 
        /// 
        /// aba, baab, bccb, abccba....
        ///         j
        ///         a   b   a   a   b   c   c   b   a
        ///  i  a   1   0   1   0   0   0   0   0   0
        ///     b   0   1   0   0   1   0   0   0   0
        ///     a   0   0   1   1   0   0   0   0   0
        ///     a   0   0   0   1   0   0   0   0   1
        ///     b   0   0   0   0   1   0   0   1   0
        ///     c   0   0   0   0   0   1   1   0   0
        ///     c   0   0   0   0   0   0   1   0   0
        ///     b   0   0   0   0   0   0   0   1   0
        ///     a   0   0   0   0   0   0   0   0   1
        ///  
        /// if i == j then yes since it's the same letter but we don't want to add this to the result
        /// if s[i] == s[i + 1] then yes since it's the same repeating letter (aa or cc)
        /// if s[i] == s[j] then dp[i,j] = dp[i+1, j-1]
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static List<string> AllPalindromes(string word)
        {
            List<string> result = new List<string>();

            int[,] cache = new int[word.Length, word.Length];
            
            for(int i = 0; i < word.Length; i++) {
                //base case 1...same letter
                cache[i, i] = 1;

                //base case 2...repeating letter
                if (i < (word.Length - 1)) {
                    if (word[i] == word[i + 1]) {
                        cache[i, i + 1] = 1;
                        result.Add(word.Substring(i, 2));
                    }
                }
            }

            //since we look at i + 1...we want to build i from high to low
            for(int i = (word.Length - 1); i >= 0; i--) {
                for(int j = i + 1; j < word.Length; j++) {
                    if (cache[i, j] != 1)
                    {
                        cache[i, j] = ((word[i] == word[j]) && (cache[i + 1, j - 1] == 1)) ? 1 : 0;
                    }
                    if ((cache[i, j] == 1) && ((j - i) >= 2)) {
                        result.Add(word.Substring(i, j - i + 1));
                    }
                }
            }

            return result;
        }
        
        #endregion

        #region Longest Increasing Sub Sequence

        /// <summary>
        /// 10, 22, 9, 33, 21, 50, 41, 60, 80
        /// 
        /// 10, 22, 33, 50, 60, 80 -> length 6
        /// 
        /// recurrence
        /// for each number, find the max length within the sub sequence up to current numbers
        /// 
        /// complexity 2^n
        /// 
        ///                  f(4)
        ///        f(3)      f(2)       f(1)
        ///  f(2)       f(1) f(1)
        ///  f(1)
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int LongestIncreasingSubSequenceRecursive(int[] numbers)
        {
            return LongestIncreasingSubSequenceRecursive(numbers, numbers.Length - 1);
        }

        private static int LongestIncreasingSubSequenceRecursive(int[] numbers, int currentIndex)
        {
            if (currentIndex == 0)
            {
                return 1;
            }

            int length = 0;

            for (int index = 0; index < currentIndex; index++)
            {
                if (numbers[index] < numbers[currentIndex]) {
                    length = System.Math.Max(length, 1 + LongestIncreasingSubSequenceRecursive(numbers, index));
                }
            }

            return length;
        }

        /// <summary>
        ///         10  22  9   33  21  50  41  60  80
        /// 10      1   
        /// 22      1   2   
        /// 9       0   0   1   
        /// 33      1   2   2   3   
        /// 21      1   1   1   1   2   
        /// 50      1   2   2   3   3   4   
        /// 41      1   2   2   3   3   3   4   
        /// 60      1   2   2   3   3   4   4   5   
        /// 80      1   2   2   3   3   4   4   5   6
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int LongestIncreasingSubSequenceDynamic(int[] numbers)
        {
            int[] cache = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                //worst case, it will be 1 which is by itself
                int max = 1;

                //iterate up to previous index
                for (int j = 0; j < i; j++)
                {
                    //if previous number is smaller, we can include this count + 1
                    if (numbers[i] >= numbers[j])
                    {
                        max = System.Math.Max(max, cache[j] + 1);
                    }
                }
                cache[i] = max;
            }

            return cache[numbers.Length - 1];
        }

        /// <summary>
        /// Think of how human will do this, lets try to track all possible sequences but also optimize
        /// what we track
        /// 
        /// 10
        /// 
        /// 10
        /// 10, 22
        /// 
        /// 9,  here 9 & 10 are redundent because they both give us sequence of length 1...
        /// 10, if we want to maximize our chance (let's say there is 10 again) we should keep the lowest
        /// 10, 22
        /// 
        /// 9,
        /// 10, 22
        /// 10, 22, 33
        /// 
        /// 9,
        /// 10, 21 (same as previous, replace 22 with 21)
        /// 10, 22, 33
        /// 
        /// 9,
        /// 10, 21,
        /// 10, 22, 33,
        /// 10, 22, 33, 50
        /// 
        /// we can simplify this rule
        /// have a 1-D array of tail values 9, 21, 33, 50. If the number is smaller than number at index 0, replace
        /// if the number is larger than last number, extend the array. If the number is in between, replace
        /// the next larger value
        /// 
        /// nlogn complexity
        /// </summary>
        /// <param name="numbers"></param>
        public static int LongestIncreasingSubSequenceBinarySearch(int[] numbers) {
            List<int> tailCache = new List<int>();
            
            foreach(int number in numbers) {
                if ((tailCache.Count == 0) || (tailCache[tailCache.Count - 1] < number))
                {
                    tailCache.Add(number);
                }
                else if (tailCache[0] > number)
                {
                    tailCache[0] = number;
                }
                else
                {
                    //in between...find the next largest
                    int start = 0;
                    int end = tailCache.Count - 1;
                    int nextIndex = end;
                    int next = int.MaxValue;

                    while (start <= end)
                    {
                        int mid = start + (int)System.Math.Floor((end - start) / 2d);
                        if (tailCache[mid] <= number)
                        {
                            start = mid + 1;
                        }
                        else
                        {
                            if (tailCache[mid] < next)
                            {
                                next = tailCache[mid];
                                nextIndex = mid;
                            }
                            end = mid - 1;
                        }
                    }

                    tailCache[nextIndex] = number;
                }
            }

            return tailCache.Count;
        }

        #endregion
                
        #region Break Word

        /// <summary>
        /// Give a dictionary of valid words and a text, return whether the text can be broken into all valid words
        /// 
        /// { i, like, sam, sung, samsung, mobile, ice, cream, icecream, man, go, mango}
        /// 
        /// ilike -> true (i like)
        /// ilikesamsung -> true (i like samsung or i like sam sung)
        /// 
        /// Complexity 2^n
        /// </summary>
        /// <param name="text"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static bool BreakWordRecursive(string text, List<string> dictionary)
        {
            return BreakWordRecursive(text, 0, text.Length - 1, dictionary);
        }

        private static bool BreakWordRecursive(string text, int startIndex, int endIndex, List<string> dictionary)
        {
            //if it's one character, this is simply looking up the dictionary for the valid single characters
            if (endIndex == startIndex)
            {
                return dictionary.Contains(text.Substring(startIndex, 1));
            }

            //now try all variation of the sub text from the existing text
            for (int index = startIndex; index <= endIndex; index++)
            {
                string word = text.Substring(startIndex, index - startIndex + 1);
                //if it's a valid word, test the rest of the text
                if (dictionary.Contains(word))
                {
                    if (index < endIndex) {
                        if (BreakWordRecursive(text, index + 1, endIndex, dictionary))
                        {
                            return true;
                        }
                    }
                    else {
                        return true;
                    }
                }
            }

            return false;
        }
        
        /// <summary>
        /// if dictionary is small...then you can reduce complexity by using dictionary to deliminate the words
        /// and then iterate
        /// 
        /// o(n * m) where m is the size of the dictionary
        /// </summary>
        /// <param name="text"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static bool BreakWordSmallDictionary(string text, List<string> dictionary)
        {
            bool[] valid = new bool[text.Length + 1];
            valid[0] = true;

            for (int index = 0; index < text.Length; index++)
            {
                if (!valid[index])
                {
                    //only evaluate from last match
                    continue;
                }

                //now loop through all words in dictionary and try to find all valid words
                foreach (string word in dictionary)
                {
                    //minor optimization...check length of the word in dictionary and see if it will fit
                    int wordLength = word.Length;
                    int validLength = index + wordLength;
                    if (validLength > text.Length)
                    {
                        continue;
                    }

                    if (valid[validLength])
                    {
                        //already found...no need to do it again
                        continue;
                    }

                    //finally check if the word we found is actual equal to the string
                    if (text.Substring(index, wordLength) == word)
                    {
                        valid[validLength] = true;
                    }
                }
            }

            return valid[text.Length];
        }

        public static List<string> BreakWordTwoSmallDictionary(string text, List<string> dictionary)
        {
            List<string>[] validWords = new List<string>[text.Length + 1];
            validWords[0] = new List<string>();

            for (int index = 0; index < text.Length; index++)
            {
                if (validWords[index] == null)
                {
                    //only evaluate from last match
                    continue;
                }

                //now loop through all words in dictionary and try to find all valid words
                foreach (string word in dictionary)
                {
                    //minor optimization...check length of the word in dictionary and see if it will fit
                    int wordLength = word.Length;
                    int validLength = index + wordLength;
                    if (validLength > text.Length)
                    {
                        continue;
                    }

                    //finally check if the word we found is actual equal to the string
                    if (text.Substring(index, wordLength) == word)
                    {
                        List<string> words = validWords[validLength];
                        if (words == null)
                        {
                            words = new List<string>();
                            validWords[validLength] = words;
                        }
                        words.Add(word);
                    }
                }
            }

            List<string> result = new List<string>();

            if (validWords[text.Length] != null)
            {
                //whole text is valid...we could have partial result but whole text may not be valid
                GetWords(validWords, text.Length, result, new List<string>());
            }

            return result;
        }

        private static void GetWords(List<string>[] validWords, int end, List<string> result, List<string> path)
        {
            if (end == 0)
            {
                //we are done, add this as a result
                StringBuilder text = new StringBuilder();
                foreach (string word in path)
                {
                    if (text.Length > 0)
                    {
                        text.Append(" ");
                    }
                    text.Append(word);
                }
                result.Add(text.ToString());
                return;
            }

            foreach (string word in validWords[end])
            {
                path.Insert(0, word);
                GetWords(validWords, end - word.Length, result, path);
                path.RemoveAt(0);
            }
        }

        /// <summary>
        /// 
        ///         j       i   l   i   k   e   s   a   m   s   u   n   g
        /// i
        /// i               1               1           1               1
        /// l                   0           1           1               1
        /// i                       1
        /// k                           0
        /// e                               0
        /// s                                   0   0   1   0   0   0   1
        /// a                                       0   0   0   0   0   0
        /// m                                           0   0   0   0   0
        /// s                                               0   0   0   1
        /// u                                                   0   0   0
        /// n                                                       0   0
        /// g                                                           0
        /// </summary>
        /// <param name="text"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static bool BreakWordDynamic(string text, List<string> dictionary)
        {
            bool[,] valid = new bool[text.Length, text.Length];

            for(int j = 0; j < text.Length; j++) {
                valid[j, j] = dictionary.Contains(text[j].ToString());
            }

            for (int i = text.Length - 2; i >= 0; i--)
            {
                int lastBreak = valid[i, i] ? i : -1;
                for (int j = i + 1; j < text.Length; j++)
                {
                    string word = text.Substring(i, j - i + 1);
                    if (dictionary.Contains(word))
                    {
                        valid[i, j] = true;
                        lastBreak = j;
                    }
                    else if ((lastBreak > -1) && ((lastBreak + 1) < text.Length))
                    {
                        valid[i, j] = valid[lastBreak + 1, j];
                    }
                }
            }

            return valid[0, text.Length - 1];
        }

        /// <summary>
        /// 
        ///         j       i   l   i   k   e   s   a   m   s   u   n   g
        /// i
        /// i               1               1           1               2
        /// l                   0           1           1               2
        /// i                       1
        /// k                           0
        /// e                               0
        /// s                                   0   0   1   0   0   0   2
        /// a                                       0   0   0   0   0   0
        /// m                                           0   0   0   0   0
        /// s                                               0   0   0   1
        /// u                                                   0   0   0
        /// n                                                       0   0
        /// g                                                           0
        /// </summary>
        /// <param name="text"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static List<string> BreakWordTwoDynamic(string text, List<string> dictionary)
        {
            int[,] valid = new int[text.Length, text.Length];

            for (int j = 0; j < text.Length; j++)
            {
                valid[j, j] = dictionary.Contains(text[j].ToString()) ? 1 : 0;
            }

            for (int i = text.Length - 2; i >= 0; i--)
            {
                int lastBreak = valid[i, i] == 1 ? i : -1;
                for (int j = i + 1; j < text.Length; j++)
                {
                    string word = text.Substring(i, j - i + 1);
                    
                    if ((lastBreak > -1) && ((lastBreak + 1) < text.Length))
                    {
                        valid[i, j] = valid[lastBreak + 1, j];
                    }
                    if (dictionary.Contains(word))
                    {
                        valid[i, j] += 1;
                        lastBreak = j;
                    }
                }
            }

            List<string> result = new List<string>();
            result.Add("");

            for (int j = 0; j < text.Length; j++)
            {
                //we want to do this for every possible string in result set
                for (int i = 0; i < result.Count; i++)
                {
                    //add current char
                    result[i] += text[j];

                    //if valid has a number higher than 0 we want to add space
                    if (valid[0, j] > 0)
                    {
                        result[i] += " ";
                    }
                }

                //now if the valid has a number higher than 1, that means we have a word consisting of one or more words
                //since our reference is the very first result, duplicate and eliminate the correct number of spaces
                if (valid[0, j] > 1)
                {
                    int resultCount = result.Count;
                    for (int resultIndex = 0; resultIndex < resultCount; resultIndex++)
                    {
                        string duplicate = result[resultIndex];
                        int lastSpaceIndex = duplicate.LastIndexOf(' ') - 1;
                        for (int space = 1; space < valid[0, j]; space++)
                        {
                            //since we add a space at the end, we need to search for second last
                            int secondLastSpaceIndex = duplicate.LastIndexOf(' ', lastSpaceIndex);
                            duplicate = duplicate.Remove(secondLastSpaceIndex, 1);
                            lastSpaceIndex = secondLastSpaceIndex - 1;
                        }
                        result.Add(duplicate);
                    }
                }
            }

            return result;
        }

        #endregion

        #region Parenthesization

        /// <summary>
        /// Given a set of numbers and operations
        /// 
        /// 1 + 5 * 20 / 5 + 20 - 30
        /// 
        /// Find the parenthesization which gives lowest answer
        /// 
        /// What we want
        /// Find the last operation
        /// 
        /// ( ) ? ( ) gives you the smallest answer
        /// (Ai -> Ak) ? (Ak + 1 -> Aj)
        /// 
        /// Total cost is 4 ^ n
        /// 
        /// Sub problem is sub string (n ^ 2)
        /// Recurrence is Ai -> Aj (n)
        /// 
        /// So we want
        /// DP(i, k) + DP(k + 1, j) + Cost of last operation
        /// </summary>
        /// <returns></returns>
        public static int Parenthesize()
        {
            return 0;
        }

        #endregion

        #region Boggle

        //have a grid of letters and a dictionary
        //the objective is to find all possible valid words of length 3+

        //naive - for each letter do dfs and check each substring against dictionary - O(n^2 m^2)
        //better - create a trie with the dictionary and conditionally dfs if prefix exists - O( n m w ) + O(w l) 
        //      where w is max length of word in dictionary and l is number of words in dictionary
        //dp - eliminate words from the dictionary by checking if the word can be formed using the boggle board

        

        #endregion

    }

}
