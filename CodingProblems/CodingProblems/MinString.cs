namespace CodingProblems
{
    public class MinString
    {
        /*
        Input string1: "this is a test string"
Input string2: "tist"
Output string: "t stri"*/

        private static bool IsComplete(int[] currentHistogram, int[] targetHistogram)
        {
            for (int i = 0; i < currentHistogram.Length; i++)
            {
                if (currentHistogram[i] < targetHistogram[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static string MinSubstring(string firstString, string secondString)
        {
            int[] histogram = new int['z' - 'a' + 1];
            for (int i = 0; i < secondString.Length; i++)
            {
                if (secondString[i] == ' ')
                    continue;

                histogram[secondString[i] - 'a']++;
            }

            int bestStart = 0;
            int bestEnd = 0;
            int start = 0;
            int[] histogram1 = new int['z' - 'a' + 1];
            for (int end = 0; end < firstString.Length; end++)
            {
                if (firstString[end] == ' ')
                    continue;

                histogram1[firstString[end] - 'a']++;
                if (IsComplete(histogram1, histogram))
                {
                    for (; start < end && IsComplete(histogram1, histogram); start++)
                    {
                        if (firstString[start] == ' ')
                            continue;

                        histogram1[firstString[start] - 'a']--;
                    }

                    bestStart = start - 1;
                    bestEnd = end;
                }
            }

            return firstString.Substring(bestStart, bestEnd - bestStart + 1);
        }
    }
}
