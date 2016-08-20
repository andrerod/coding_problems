using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    public class QueueWithTwoStacks
    {
        private readonly Stack<object> _holder = new Stack<object>();
        private readonly Stack<object> _popper = new Stack<object>();

        public void Enqueue(object value)
        {
            _holder.Push(value);
        }

        public object Dequeue()
        {
            //first check popper does not have items in reverse order
            if (_popper.Count == 0)
            {
                //now see if there are any items in the holder to be reversed
                while (_holder.Count > 0)
                {
                    _popper.Push(_holder.Pop());
                }
            }

            if (_popper.Count != 0)
            {
                return _popper.Pop();
            }

            return null;
        }
    }
}
