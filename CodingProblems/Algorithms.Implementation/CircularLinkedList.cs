using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Implementation.Models;

namespace Algorithms.Implementation
{
    public class CircularLinkedList
    {
        public Node Head { get; set; }

        public bool Detect()
        {
            var circular = false;
            var slow = Head;
            var fast = Head;

            while (slow != null && slow.Next != null && fast != null && fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == Head || fast == Head || slow == fast)
                {
                    circular = true;
                    break;
                }
            }

            return circular;
        }

        public void InsertSorted(object value)
        {
            if (Head == null)
            {
                Head = new Node {Value = value};
                Head.Next = Head;
            }
            else
            {
                if ((int)value < (int)Head.Value)
                {
                    //when value is smaller than head, make a copy of the head and set head's value to the new value, then change the head
                    var headCopy = new Node {Next = Head.Next, Value = Head.Value};

                    Head.Next = headCopy;
                    Head.Value = value;
                }
                else
                {
                    var currentItem = Head;
                    while (currentItem.Next != Head && (int)currentItem.Next.Value <= (int)value)
                    {
                        currentItem = currentItem.Next;
                    }

                    currentItem.Next = new Node {Next = currentItem.Next, Value = value};
                }
            }
        }
        
        public void InsertAtEnd(object value)
        {
            if (Head == null)
            {
                //handle null head
                Head = new Node { Value = value };
                Head.Next = Head;
            }
            else
            {
                var headCopy = new Node
                                   {
                                       Next = Head.Next,
                                       Value = Head.Value
                                   };

                Head.Next = headCopy;
                Head.Value = value;

                //don't forget to reset the head back to the copy
                Head = headCopy;
            }
        }
    }
}
