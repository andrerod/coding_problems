using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{

    public class Celebrity
    {
        
        /// <summary>
        /// Celebrity doesn't know anyone
        /// Everyone knows celebrity
        /// 
        /// Take one person and apply the above logic (A doesn't know B, B knows A)
        /// if this is true, consider this person as a possible candidate and do this with the next person (A <-> C)
        /// When we find another candidate, the current one has to be not the celebrity since this person knows the new one
        /// Do this until there is noone left and verify since the person may not be a celebrity. last person may satisfy this condition
        /// but doesn't mean this person is a celebrity
        /// </summary>
        public static int Find(bool[,] matrix)
        {
            int candidate = 0;
            for (int current = 1; current < matrix.GetUpperBound(0); current++)
            {
                //same person
                if (candidate == current)
                {
                    continue;
                }

                //current doesn't know candidate
                //candidate knows current
                //new candidate
                if ((!matrix[current, candidate]) && (matrix[candidate, current]))
                {
                    candidate = current;
                }
            }

            //need to check
            for (int count = 0; count < matrix.GetUpperBound(0); count++)
            {
                //if this person knows someone then cannot be celebrity
                if (matrix[candidate, count])
                {
                    throw new ArgumentException();
                }
            }

            return candidate;
        }

    }
}
