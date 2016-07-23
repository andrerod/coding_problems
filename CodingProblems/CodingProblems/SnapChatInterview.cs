using System.Collections.Generic;

namespace CodingProblems
{
    public class SnapChatInterview
    {
        public static int Problem1(int [] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers[0];
            }

            HashSet<int> seen = new HashSet<int>();
            foreach (var number in numbers)
            {
                if (seen.Contains(number))
                {
                    return number;
                }
                else
                {
                    seen.Add(number);
                }
            }

            return -1;
        }

        public static int Problem2(int[] numbers)
        {
            int i = 0;
            int j = numbers.Length - 1;
            while (i <= j)
            {
                if (numbers[i] == numbers[j])
                {
                    return numbers[i];
                }
                i++;
                j--;
            }

            return numbers[i];
        }

        public static int Problem3(int[] numbers)
        {
            var target = -1;

            int i = 0;
            int j = numbers.Length - 1;
            while (i <= j)
            {
                if (numbers[i] == numbers[j])
                {
                    target = numbers[i];
                    break;
                }
                i++;
                j--;
            }

            if (target == -1)
            {
                target = numbers[i];
            }

            int ocurrences = 0;
            foreach (var number in numbers)
            {
                if (number == target)
                {
                    ocurrences++;
                    if (ocurrences > (numbers.Length / 2))
                    {
                        return target;
                    }
                }
            }

            return -1;
        }


        public static Stack<int> FindPath(int [] numbers)
        {
            var visited = new bool[numbers.Length];
            Stack<int> path = new Stack<int>();
            path.Push(0);
            if (FindPath(0, numbers, path, visited))
            {
                return path;
            }

            return null;
        }

        private static bool FindPath(int currentPosition, int[] numbers, Stack<int> currentPath, bool[] visited)
        {
            if (currentPosition == numbers.Length - 1)
            {
                return true;
            }

            if (currentPosition > numbers.Length - 1 || visited[currentPosition])
            {
                return false;
            }

            int currentNumber = numbers[currentPosition];
            for (int i = currentPosition + 1; i <= currentPosition + currentNumber && i < numbers.Length; i++)
            {
                currentPath.Push(i);
                if (FindPath(i, numbers, currentPath, visited))
                {
                    return true;
                }
                else
                {
                    currentPath.Pop();
                    visited[i] = true;
                }
            }

            return false;
        }

        public static Stack<int> FindShortestPath(int[] numbers)
        {
            var costFromPoint = new int[numbers.Length];
            var nextFromPoint = new int[numbers.Length];

            for (int i = 0; i < costFromPoint.Length; i++)
            {
                nextFromPoint[i] = -1;
            }

            for (int i = 0; i < costFromPoint.Length; i++)
            {
                costFromPoint[i] = int.MaxValue;
            }

            if (FindShortestPath(0, numbers, costFromPoint, nextFromPoint) != int.MaxValue)
            {
                int currentPosition = 0;
                Stack<int> path = new Stack<int>();
                while (currentPosition != numbers.Length - 1)
                {
                    path.Push(currentPosition);
                    currentPosition = nextFromPoint[currentPosition];
                }

                return path;
            }

            return null;
        }

        private static int FindShortestPath(int currentPosition, int[] numbers, int[] costFromPoint, int[] nextFromPoint)
        {
            if (currentPosition == numbers.Length - 1)
            {
                return 0;
            }

            if (currentPosition > numbers.Length - 1)
            {
                return int.MaxValue;
            }

            int currentNumber = numbers[currentPosition];
            for (int i = currentPosition + 1; i <= currentPosition + currentNumber && i < numbers.Length; i++)
            {
                int costTillEnd = FindShortestPath(i, numbers, costFromPoint, nextFromPoint) + 1;
                if (costTillEnd != int.MaxValue)
                {
                    if (costTillEnd < costFromPoint[currentPosition])
                    {
                        costFromPoint[currentPosition] = costTillEnd;
                        nextFromPoint[currentPosition] = i;
                    }
                }
            }

            return costFromPoint[currentPosition];
        }

        public int FindUnique(int[] numbers)
        {
            int equalsOne = 0;

            Dictionary<int, int> existing = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (existing.ContainsKey(number))
                {
                    equalsOne--;
                    existing[number]++;
                }
                else
                {
                    equalsOne++;
                    existing[number] = 1;
                }
            }

            foreach (var number in numbers)
            {
                if (existing[number] == 1)
                {
                    return number;
                }
            }

            return -1;
        }
    }
}


/*
    public int ladderLength(String beginWord, String endWord, Set<String> wordDict) {
        if (wordDict == null || wordDict.size() == 0) {
            return 0;
        }

        LinkedList<String> queue = new LinkedList<String>();
        queue.offer(beginWord);
        wordDict.remove(beginWord);
        int length = 1;
        while (!queue.isEmpty()) {
            int count = queue.size();
            for (int j = 0; j < count; j++) {
                String crt = queue.poll();
                for (char c = 'a'; c <= 'z'; c++) {
                    for (int i = 0; i < crt.length(); i++) {
                        if (c == crt.charAt(i)) {
                            continue;
                        }
                        String replaced = replace(crt, i, c);
                        if (replaced.equals(endWord)) {
                            return length + 1;
                        }

                        if (wordDict.contains(replaced)) {
                            queue.offer(replaced);
                            wordDict.remove(replaced);
                        }
                    }
                }
            }
            length++;
        }

        return 0;
    }
}
*/