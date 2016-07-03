using System;

namespace CodingProblems
{
    public class GraphEdge<T> : IComparable
    {
        public T Node { get; set; }

        public int Distance { get; set; }

        public int CompareTo(object obj)
        {
            return Distance - ((GraphEdge<T>)obj).Distance;
        }
    }
}
