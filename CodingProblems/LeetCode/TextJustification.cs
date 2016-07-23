using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class TextJustification
    {
        public static IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> results = new List<string>();
            int i = 0; // current word in words
            while (i < words.Length)
            {
                int wordsInLine = 0; // number of words in current line
                int lineLength = 0; // length of words in current line excluding whitespace
                while (i + wordsInLine < words.Length && lineLength + words[i + wordsInLine].Length <= maxWidth - wordsInLine)
                {
                    lineLength += words[i + wordsInLine].Length;
                    wordsInLine++;
                }

                string line = words[i];

                var spaces = wordsInLine > 1 ? (maxWidth - lineLength) / (wordsInLine - 1) : 0;
                var extraSpaces = wordsInLine > 1 ? (maxWidth - lineLength) % (wordsInLine - 1) : 0;
                for (int j = 0; j < wordsInLine - 1; j++)
                {
                    if (i + wordsInLine >= words.Length)
                    {
                        line += " "; // last line only one space between words
                    }
                    else
                    {
                        line += new string(' ', spaces + (extraSpaces-- > 0 ? 1 : 0));
                    }

                    line += words[i + j + 1];
                }

                line += new string(' ', maxWidth - line.Length);
                results.Add(line);
                i += wordsInLine;
            }

            return results;
        }
    }
}
