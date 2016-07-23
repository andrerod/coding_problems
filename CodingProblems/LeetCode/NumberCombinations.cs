using System.Collections.Generic;

namespace ClassLibrary2
{
    public class NumberCombinations
    {
        public static List<List<int>> Combinations(int n)
        {
            List<List<int>> result = new List<List<int>>();

            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = i + 1;
            }

            bool[] visited = new bool[n];
            DFS(numbers, 0, result, new Stack<int>(), visited);
            return result;
        }

        private static void DFS(int[] num, int togo, List<List<int>> result, Stack<int> current, bool[] visited)
        {
            if (togo == visited.Length)
            {
                result.Add(new List<int>(current));
            }

            for (int i = 0; i < num.Length; i++)
            {
                if (!visited[i])
                {
                    current.Push(num[i]);
                    visited[i] = true;
                    DFS(num, togo + 1, result, current, visited);
                    current.Pop();
                    visited[i] = false;
                }
            }
        }
    }
}
