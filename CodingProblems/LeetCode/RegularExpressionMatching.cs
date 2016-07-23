namespace ClassLibrary2
{
    public class RegularExpressionMatching
    {
        public bool IsMatch(string input, string pattern)
        {
            bool[] match = new bool[input.Length + 1];
            for (int i = 0; i < match.Length; i++)
            {
                match[i] = false;
            }

            match[input.Length] = true;
            for (int i = pattern.Length - 1; i >= 0; i--)
            {
                if (pattern[i] == '*')
                {
                    for (int j = input.Length - 1; j >= 0; j--)
                    {
                        match[j] = match[j] || match[j + 1] && (pattern[i - 1] == '.' || pattern[i - 1] == input[j]);
                    }

                    i--;
                }
                else
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        match[j] = match[j + 1] && (pattern[i] == '.' || pattern[i] == input[j]);
                    }
                    match[input.Length] = false;
                }
            }

            return match[0];
        }
    }
}
