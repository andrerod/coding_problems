using System.Collections.Generic;

namespace ClassLibrary2
{
    public class Generate
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> results = new List<string>();
            GenerateParentheses("", n, n, results);
            return results;
        }

        private void GenerateParentheses(string current, int open, int close, List<string> results)
        {
            if (open == 0 && close == 0)
            {
                results.Add(current);
            }

            if (close > open)
            {
                GenerateParentheses(current + ")", open, close - 1, results);
            }

            if (open > 0)
            {
                GenerateParentheses(current + "(", open - 1, close, results);
            }
        }
    }
}
