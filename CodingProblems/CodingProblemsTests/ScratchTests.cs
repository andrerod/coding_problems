using System;
using System.Collections.Generic;

namespace CodingProblemsTests
{
    public class ScratchTests
    {
        public static List<int> ShortestPath(int[] input)
        {
            var bestDistanceToPosition = new Dictionary<int, int>();
            var nodesToVisit = new Heap<int>((a, b) => bestDistanceToPosition[a] - bestDistanceToPosition[b]);
            var path = new List<int>();
            var previous = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    bestDistanceToPosition[i] = 0;
                }
                else
                {
                    bestDistanceToPosition[i] = int.MaxValue;
                }

                nodesToVisit.Add(i);
            }

            while (nodesToVisit.Elements.Count > 0)
            {
                // Find node with minimum distance to
                var closestNode = nodesToVisit.Pop();
                if (closestNode == (input.Length - 1))
                {
                    path = new List<int>();
                    while (closestNode != 0)
                    {
                        path.Add(closestNode);
                        closestNode = previous[closestNode];
                    }

                    path.Reverse();
                    return path;
                }

                if (bestDistanceToPosition[closestNode] == int.MaxValue)
                {
                    return null;
                }

                for (int i = 1; i <= input[closestNode] && closestNode + i < input.Length; i++)
                {
                    var distanceToNext = bestDistanceToPosition[closestNode] + 1;
                    if (distanceToNext < bestDistanceToPosition[closestNode + i])
                    {
                        bestDistanceToPosition[closestNode + i] = distanceToNext;

                        // TODO: need to bubble up the vertex in the heap
                        nodesToVisit.Heapify(nodesToVisit.Positions[closestNode + i]);

                        previous[closestNode + i] = closestNode;
                    }
                }
            }

            return null;
        }

        public class Heap<T>
        {
            public List<T> Elements { get; set; }
            public Dictionary<T, int> Positions { get; set; }

            private Comparison<T> Comparer { get; set; }

            public Heap(Comparison<T> comparer)
            {
                Comparer = comparer;
            }

            public void Add(T element)
            {
                Elements.Add(element);
                Positions[element] = Elements.Count - 1;
                Heapify(Elements.Count - 1);
            }

            public T Pop()
            {
                var tmp = Elements[0];
                Elements[0] = Elements[Elements.Count - 1];
                Positions[Elements[0]] = 0;
                Elements.RemoveAt(Elements.Count - 1);

                // Heapify downards
                for (int i = 0; i < Elements.Count;)
                {
                    var larger = 2 * i + 1;
                    if (Comparer.Invoke(Elements[2 * i + 2], Elements[2 * i + 1]) > 0)
                    {
                        larger = 2 * i + 2;
                    }

                    if (Comparer.Invoke(Elements[larger], Elements[i]) > 0)
                    {
                        var tmp2 = Elements[larger];
                        Elements[larger] = Elements[i];
                        Elements[i] = tmp2;
                        Positions[Elements[larger]] = larger;
                        Positions[Elements[i]] = i;

                        i = larger;
                    }
                    else
                    {
                        break;
                    }
                }

                return tmp;
            }

            public void Heapify(int index)
            {
                for (int i = index; i >= 1; i = (i - 1) / 2)
                {
                    if (Comparer.Invoke(Elements[i], Elements[(i - 1) / 2]) > 0)
                    {
                        var tmp = Elements[(i - 1) / 2];
                        Elements[(i - 1) / 2] = Elements[i];
                        Elements[i] = tmp;
                        Positions[Elements[(i - 1) / 2]] = (i - 1) / 2;
                        Positions[Elements[i]] = i;
                    }
                }
            }
        }
    }
}
