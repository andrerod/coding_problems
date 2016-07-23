using System;

namespace CodingProblems
{
    public class MazeLocation<T> : IComparable
    {
        public T Node { get; set; }
        
        public int GScore { get; set; }

        public int FScore { get; set; }

        public int CompareTo(object obj)
        {
            return FScore - ((MazeLocation<T>)obj).FScore;
        }
    }
}
