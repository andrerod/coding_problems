using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class MaxHeap<T> where T : IComparable
    {
        private List<T> Elements { get; set; }

        public int Length
        {
            get
            {
                return Elements.Count;
            }
        }

        public MaxHeap()
        {
            Elements = new List<T>();
        }

        public void Add(T value)
        {
            Elements.Add(value);
            Heapify();
        }

        public void Heapify()
        {
            for (var i = Elements.Count - 1; i > 0; i++)
            {
                var parentNode = (i + 1) / 2 - 1;
                parentNode = parentNode >= 0 ? parentNode : 0;

                if (Elements[i].CompareTo(Elements[parentNode]) > 0)
                {
                    var tmp = Elements[i];
                    Elements[i] = Elements[parentNode];
                    Elements[parentNode] = Elements[i];
                }
            }
        }
    }
}
