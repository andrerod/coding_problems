using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class MinHeap<T> where T : IComparable
    {
        private List<T> elements;

        public int Length
        {
            get
            {
                return elements.Count;
            }
        }


        public MinHeap()
        {
            elements = new List<T>();
        }

        public void Add(T item)
        {
            elements.Add(item);
            Heapify();
        }

        public void Delete(T item)
        {
            int i = elements.IndexOf(item);
            int last = elements.Count - 1;

            elements[i] = elements[last];
            elements.RemoveAt(last);
            Heapify();
        }

        public T PopMin()
        {
            if (elements.Count > 0)
            {
                T item = elements[0];
                Delete(item);
                return item;
            }
            //relook at this - should we just throw exception?
            return default(T);
        }

        public void Heapify()
        {
            for (int i = elements.Count - 1; i > 0; i--)
            {
                int parentPosition = (i + 1) / 2 - 1;
                parentPosition = parentPosition >= 0 ? parentPosition : 0;

                if (elements[parentPosition].CompareTo(elements[i]) > 1)
                {
                    T tmp = elements[parentPosition];
                    elements[parentPosition] = elements[i];
                    elements[i] = tmp;
                }
            }
        }
    }
}
