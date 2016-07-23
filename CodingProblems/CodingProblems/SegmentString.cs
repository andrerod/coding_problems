using System.Collections.Generic;

namespace CodingProblems
{
    public class SegmentString
    {
        private string Input { get; set; }

        private HashSet<string> Words { get; set; }

        private HashSet<string> InvalidPrefixes { get; set; }

        public SegmentString(string input, HashSet<string> words)
        {
            Input = input;
            Words = words;
            InvalidPrefixes = new HashSet<string>();
        }

        public string Segment()
        {
            return Segment(Input);
        }

        private string Segment(string input)
        {
            if (Words.Contains(input))
            {
                return input;
            }

            if (InvalidPrefixes.Contains(input))
            {
                return null;
            }

            for (int i = 1; i < input.Length; i++)
            {
                string prefix = input.Substring(0, i);
                if (Words.Contains(prefix))
                {
                    string suffix = input.Substring(i);
                    string segSuffix = Segment(suffix);
                    if (segSuffix != null)
                    {
                        return prefix + " " + segSuffix;
                    }
                }
            }

            InvalidPrefixes.Add(input);
            return null;
        }
    }
}
