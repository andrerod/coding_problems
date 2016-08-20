using System;

using Algorithms.Implementation.Models;
using System.Collections.Generic;

namespace Algorithms.Implementation
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public void Remove(int value)
        {
            if (Head == null)
            {
                throw new InvalidOperationException();
            }

            while (Head != null && (int)Head.Value == value)
            {
                Head = Head.Next;
            }

            if (Head != null)
            {
                var previousNode = Head;
                var currentNode = Head.Next;
                while (currentNode != null)
                {
                    if ((int)currentNode.Value == value)
                    {
                        previousNode.Next = currentNode.Next;
                    }
                    else
                    {
                        previousNode = currentNode;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }
        
        public void Reverse()
        {
            if (Head != null)
            {
                ReverseNeighbor(Head);
            }
        }

        private void ReverseNeighbor(Node node)
        {
            if (node.Next != null)
            {
                var neighbor = node.Next;
                ReverseNeighbor(neighbor);

                neighbor.Next = node;
                node.Next = null;
            }
            else
            {
                Head = node;
            }
        }

        /*
         * node = head, neighbor = second
         * node = second, neighbor = third
         * head = third
         * third.next = second, second.next = null
         * second.next = head, head.next = null
         */

        private Node currentNode;

        public TreeNode<T> ConvertToBst<T>()
        {
            //reconstruct the tree in a similar manner to depth first in order traversal
            
            //if we know the length, we know that current node should be mid
            int length = 0;
            Node node = this.Head;
            while (node != null)
            {
                length++;
                node = node.Next;
            }

            this.currentNode = this.Head;

            return this.ConvertToBst<T>(0, length - 1);
        }

        private TreeNode<T> ConvertToBst<T>(int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = start + (int)System.Math.Floor((end - start) / 2d);

            //first create all left side tree.
            TreeNode<T> left = this.ConvertToBst<T>(start, mid - 1);

            //process the current node
            TreeNode<T> current = new TreeNode<T> { Value = (T)this.currentNode.Value };
            this.currentNode = this.currentNode.Next;

            //process all right side tree
            TreeNode<T> right = this.ConvertToBst<T>(mid + 1, end);

            current.Left = left;
            current.Right = right;

            return current;
        }

        #region Deep Copy With Random Pointer

        public class RandomListNode {
            public int label;
            public RandomListNode next, random;
            public RandomListNode(int x) { this.label = x; }
        };

        public static RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null)
            {
                return null;
            }

            //prevent cycle
            HashSet<int> check = new HashSet<int>();

            //hold created nodes
            Dictionary<int, RandomListNode> cache = new Dictionary<int, RandomListNode>();

            //copy of the head
            RandomListNode copyHead = new RandomListNode(head.label);
            RandomListNode copyCurrent = copyHead;

            while (head != null)
            {
                if (head.random != null)
                {
                    RandomListNode copyRandom = cache.ContainsKey(head.random.label)
                        ? cache[head.random.label]
                        : new RandomListNode(head.random.label);
                    cache[head.random.label] = copyRandom;
                    copyCurrent.random = copyRandom;
                }
                if (head.next != null)
                {
                    RandomListNode copyNext = cache.ContainsKey(head.next.label)
                        ? cache[head.next.label]
                        : new RandomListNode(head.next.label);
                    cache[head.next.label] = copyNext;
                    copyCurrent.next = copyNext;

                    if (!check.Contains(head.next.label))
                    {
                        check.Add(head.next.label);
                        head = head.next;
                        copyCurrent = copyCurrent.next;
                    }
                }
                else
                {
                    head = null;
                }
            }

            return copyHead;
        }

        #endregion

    }
}
