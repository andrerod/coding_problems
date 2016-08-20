using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
 
    /// <summary>
    /// implement of binary heap where items are stored as binary tree node
    /// but actual storage uses an list with indexing
    /// 
    ///                 4
    ///                / \
    ///               4   8
    ///              / \ / \
    ///             9  4 12 9
    ///            / \
    ///           11 13
    ///           
    ///     4, 4, 8, 9, 4, 12, 9, 11, 13
    /// 
    ///     parent = 1/2 i if even
    ///              floor(1/2) i if odd
    ///              
    ///     left = 2i
    ///     right = 2i + 1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>
    {

        private List<T> storage = new List<T>();

        private readonly Comparison<T> comparer;

        public List<T> Storage
        {
            get
            {
                return this.storage;
            }
            set
            {
                this.storage = value;
            }
        }

        public PriorityQueue(Comparison<T> comparer) {
            this.comparer = comparer;
        }

        public T Peek()
        {
            if (this.storage.Count == 0)
            {
                throw new Exception();
            }

            return this.storage[0];
        }

        /// <summary>
        /// Remove root
        /// Move the last child to the root
        /// 
        /// Bubble down until heap property is restored. Always choose the child which is closer to the root
        ///     in case of min heap - take smaller child, in case of max heap, take larger
        ///     
        ///                 4                13                4                4
        ///                / \              / \               / \              / \
        ///               4   8            4   8             13   8           4   8
        ///              / \ / \          / \ / \           / \  / \         / \ / \
        ///             9  4 12 9        9  4 12 9         9   4 12 9       9 13 12 9
        ///            / \              /                 /                /
        ///           11 13            11                11               11
        /// </summary>
        /// <returns></returns>
        public T ExtractRoot()
        {
            T item = default(T);

            item = this.storage[0];

            if (this.storage.Count > 1)
            {
                //swap and restore heap property
                this.Swap(0, this.storage.Count - 1);
                this.storage.RemoveAt(this.storage.Count - 1);

                int nodeIndex = 0;
                int childIndex = this.GetAppropriateChildIndex(nodeIndex);

                while (childIndex > -1)
                {
                    if (this.ShouldSwap(nodeIndex, childIndex))
                    {
                        this.Swap(nodeIndex, childIndex);

                        nodeIndex = childIndex;
                        childIndex = this.GetAppropriateChildIndex(nodeIndex);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                this.storage.Clear();
            }

            return item;
        }

        /// <summary>
        /// Stick the item to the end and then bubble up until heap property is restored
        /// 
        /// e.g. for min heap where paren is smaller
        /// 
        /// adding 7, don't have to do anything
        ///     4
        ///    /
        ///   7
        ///  
        /// adding 5
        /// 
        ///     8       8       5
        ///    /       /       /
        ///   12      5       8
        ///  /       /       /  
        /// 5       12      12
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            int nodeIndex = this.storage.Count;
            int parentIndex = (int)System.Math.Floor((nodeIndex + 1) / 2d) - 1;
            this.storage.Add(item);

            while ((parentIndex >= 0) && (this.ShouldSwap(parentIndex, nodeIndex)))
            {
                this.Swap(parentIndex, nodeIndex);

                nodeIndex = parentIndex;
                parentIndex = (int)System.Math.Floor((nodeIndex + 1) / 2d) - 1;
            }
        }

        private int GetAppropriateChildIndex(int nodeIndex)
        {            
            int leftChildIndex = ((nodeIndex + 1) * 2) - 1;
            int rightChildIndex = leftChildIndex + 1;

            //need to pick the child which satisfies the heap property
            if ((this.storage.Count - 1) < leftChildIndex)
            {
                return -1;
            }
            else if ((this.storage.Count - 1) == leftChildIndex)
            {
                //since there is no right child
                return leftChildIndex;
            }

            //now if we have both left and right child, let's pick the one satisfies the heap property better
            return !this.ShouldSwap(leftChildIndex, rightChildIndex) ? leftChildIndex : rightChildIndex;
        }

        private void Swap(int index1, int index2)
        {
            T temp = this.storage[index1];
            this.storage[index1] = this.storage[index2];
            this.storage[index2] = temp;
        }

        /// <summary>
        /// See if this violates the heap property
        /// 
        /// For min heap this will return true if left is larger the right
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        private bool ShouldSwap(int index1, int index2)
        {
            int comparison = this.comparer.Invoke(this.storage[index1], this.storage[index2]);
            return comparison > 0;
        }

    }

}
