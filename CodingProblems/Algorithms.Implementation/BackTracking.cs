using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    public class BackTracking
    {

        #region Hamiltonian

        /// <summary>
        /// Use backtracking. 
        /// Try adding a point by point and then check if there is an edge and if point is already added
        /// If this attempt is not successful, then try adding a different point
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static bool HamiltonianExists(Dictionary<int, List<int>> graph)
        {
            Dictionary<int, int> check = new Dictionary<int, int>();
            List<int> path = new List<int>();

            //add one element as the starting element
            int firstElement = graph.Keys.ElementAt(0);
            path.Add(firstElement);
            check.Add(firstElement, firstElement);

            return HamiltonianExists(graph, check, path);
        }

        private static bool HamiltonianExists(Dictionary<int, List<int>> graph, Dictionary<int, int> check, List<int> path)
        {
            //now all points are added
            if (path.Count == graph.Count)
            {
                //we have to do one more check such that origin is next to the last point
                int previous = path[path.Count - 1];
                if (graph[previous].Contains(path[0]))
                {
                    return true;
                }
                return false;
            }

            //try each element
            foreach (int element in graph.Keys)
            {
                //is this a valid next path (not used and is it connected to previous)
                if (!check.ContainsKey(element))
                {
                    int previous = path[path.Count - 1];
                    if (graph[previous].Contains(element))
                    {
                        //try adding it to path and recurse to find another possible next
                        path.Add(element);
                        check.Add(element, element);

                        if (HamiltonianExists(graph, check, path))
                        {
                            //if we recursive succeed in completing the path, we are good
                            return true;
                        }

                        //if we couldn't get to an answer with this point, we need to back track and try a different point in this position
                        path.Remove(element);
                        check.Remove(element);
                    }
                }
            }

            //if we tried every combination and nothing is found, then we cannot do it
            return false;
        }

        #endregion

        #region The 100 Game

        /// <summary>
        /// In "the 100 game," two players take turns adding, to a running 
        /// total, any integer from 1..10. The player who first causes the running 
        /// total to reach or exceed 100 wins. 
        /// What if we change the game so that players cannot re-use integers? 
        /// For example, if two players might take turns drawing from a common pool of numbers 
        /// of 1..15 without replacement until they reach a total >= 100. This problem is 
        /// to write a program that determines which player would win with ideal play. 
        /// 
        /// Back tracking with some logic
        /// However there is some confusing logic, what does it mean ideal play...let's see e.g.
        /// 3 & 4, the human would do 1 & 3, 2 & 3, 3 & 1, thus impossible for player 1 to win
        /// however permutation contains 1 & 2 & 3 which allows player 1 to win
        /// </summary>
        /// <param name="range"></param>
        /// <param name="number"></param>
        public static bool Can1Win(int range, int number)
        {
            if (number > ((range + 1) * range / 2))
            {
                //triangular number, number cannot be bigger than the sum of all numbers of range
                return false;
            }

            bool[] isUsed = new bool[range];
            return Can1Win(isUsed, number, 0);
        }

        private static bool Can1Win(bool[] isUsed, int number, int turn)
        {
            //try to the biggest number to give this turn's player maximum chance to win
            for (int index = isUsed.Length - 1; index >= 0; index--)
            {
                if (!isUsed[index])
                {
                    if ((number - (index + 1)) > 0)
                    {
                        //try next turn
                        isUsed[index] = true;
                        if (Can1Win(isUsed, number - (index + 1), turn + 1))
                        {
                            return true;
                        }
                        isUsed[index] = false;
                    }
                    else
                    {
                        //this guy won
                        //since if there is a chance, this guy takes it, thus making this the ideal play
                        return ((turn % 2) == 0);
                    }
                }
            }

            return false;
        }

        #endregion

    }
}
