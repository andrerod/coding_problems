using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    
    public class Majority
    {

        /// <summary>
        /// if there is a majority in n characters it should be such that
        /// count of majority > n/2 (n/2 being all other characters)
        /// so if we add one for each repeat, subtract one for each non repeat and reset if we get to 0 (there are as
        /// many other characters than current majority), we should be left with the majority
        /// aaaaaaa bbbbbb then number of a should be 1 greater than b regardless of what order they appear
        /// 
        /// however there are edge cases due to algorithm. aaabbbc, c will come out as majority just due to the position
        /// so we still have to write checks
        /// </summary>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static char? FindMajority(char[] characters) {
            char? majorityCharacter = null;

            char lastCharacter = characters[0];
            int count = 1;
            for (int index = 1; index < characters.Length; index++)
            {
                if (lastCharacter == characters[index])
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count == 0)
                {
                    lastCharacter = characters[index];
                    count = 1;
                }
            }

            //now check
            count = 0;
            foreach (char character in characters)
            {
                if (character == lastCharacter)
                {
                    count++;
                }
            }

            if (count > (characters.Length / 2d))
            {
                //not majority
                majorityCharacter = lastCharacter;
            }

            return majorityCharacter;
        }

    }

}
