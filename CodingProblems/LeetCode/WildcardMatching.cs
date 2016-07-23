namespace ClassLibrary2
{
    public class WildcardMatching
    {
        /*
        '?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).

The matching should cover the entire input string (not partial).

The function prototype should be:
bool isMatch(const char *s, const char *p)

Some examples:
isMatch("aa","a") → false
isMatch("aa","aa") → true
isMatch("aaa","aa") → false
isMatch("aa", "*") → true
isMatch("aa", "a*") → true
isMatch("ab", "?*") → true
isMatch("aab", "c*a*b") → false*/

        public static bool IsMatch(string input, string pattern)
        {
            int inputPos = 0;
            int patternPos = 0;
            int star = -1;
            int lastI = -1;
            while (inputPos < input.Length)
            {
                if (patternPos < pattern.Length && (input[inputPos] == pattern[patternPos] || pattern[patternPos] == '?'))
                {
                    ++inputPos;
                    ++patternPos;
                }
                else if (patternPos < pattern.Length && pattern[patternPos] == '*')
                {
                    star = patternPos++;
                    lastI = inputPos;
                }
                else if (star != -1)
                {
                    // if can't find a match and currently have a current *,
                    // restore pointer i and j and use * to consume s 
                    inputPos = lastI++;
                    patternPos = star + 1;
                }
                else
                {
                    return false;
                }
            }

            while (patternPos < pattern.Length && pattern[patternPos] == '*')
            {
                ++patternPos;
            }

            return patternPos == pattern.Length;
        }
    }
}
