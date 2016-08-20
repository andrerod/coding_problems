using Algorithms.Implementation.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{

    public class Iterator
    {

        #region Deep Iterator

        public class DeepIterator<T>
        {

            private Stack<IEnumerator> stack = new Stack<IEnumerator>();
            private T current;

            public DeepIterator(IEnumerable enumerable)
            {
                stack.Push(enumerable.GetEnumerator());
            }

            public T Current
            {
                get
                {
                    return this.current;
                }
            }

            public bool MoveNext()
            {
                while (this.stack.Count > 0)
                {
                    if (this.stack.Peek().MoveNext())
                    {
                        //if we run into another iterator we need to keep iterating
                        while (this.stack.Peek().Current is IEnumerable)
                        {
                            //need to put this on top of the current one;
                            IEnumerable enumerable = (IEnumerable)this.stack.Peek().Current;

                            //need to advance to the first element since current is null until first MoveNext
                            IEnumerator enumerator = enumerable.GetEnumerator();
                            enumerator.MoveNext();

                            this.stack.Push(enumerator);
                        }

                        //now current should be type T
                        this.current = (T)this.stack.Peek().Current;

                        return true;
                    }
                    else
                    {
                        this.stack.Pop();
                    }
                }

                return false;
            }

        }

        #endregion

        #region Binary Tree - In Order

        public class BinaryTreeInOrderIterator<T>
        {

            private Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            private BinaryTree<T> bt;
            private TreeNode<T> current;

            public T Current
            {
                get
                {
                    return this.current.Value;
                }
            }

            public BinaryTreeInOrderIterator(BinaryTree<T> bt)
            {
                this.bt = bt;
                this.current = this.bt.Root;
                this.TraverseLeftTree();
            }

            public bool MoveNext()
            {
                if (this.current.Right != null)
                {
                    this.current = this.current.Right;
                    this.TraverseLeftTree();
                    
                    return true;
                }

                if (this.stack.Count > 0) 
                {
                    this.current = this.stack.Pop();

                    return true;
                }

                return false;
            }

            private void TraverseLeftTree()
            {
                while (this.current != null)
                {
                    this.stack.Push(this.current);
                    this.current = this.current.Left;
                }

                if (this.stack.Count > 0)
                {
                    this.current = this.stack.Pop();
                }
            }

        }

        #endregion

        #region Binary Tree - Post Order

        public class BinaryTreePostOrderIterator<T>
        {

            private Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            private BinaryTree<T> bt;
            private TreeNode<T> current;

            public T Current
            {
                get
                {
                    return this.current.Value;
                }
            }

            public BinaryTreePostOrderIterator(BinaryTree<T> bt)
            {
                this.bt = bt;
                this.current = this.bt.Root;
                this.TraverseSubTree();
            }

            public bool MoveNext()
            {
                if (this.stack.Count > 0)
                {
                    this.current = this.stack.Pop();

                    this.SwitchRightWithRoot(true);

                    return true;
                }

                return false;
            }

            private void TraverseSubTree()
            {
                while (this.current != null)
                {
                    if (this.current.Right != null)
                    {
                        this.stack.Push(this.current.Right);
                    }
                    this.stack.Push(this.current);
                    this.current = this.current.Left;
                }

                if (this.stack.Count > 0)
                {
                    this.current = this.stack.Pop();

                    this.SwitchRightWithRoot(false);
                }
            }

            private void SwitchRightWithRoot(bool traverseRight)
            {
                if ((this.current != null) && (this.stack.Count > 0) && (this.stack.Peek() == this.current.Right))
                {
                    TreeNode<T> right = this.stack.Pop();
                    this.stack.Push(this.current);
                    this.current = right;
                    if (traverseRight)
                    {
                        this.TraverseSubTree();
                    }
                }
            }

        }

        #endregion

    }
}
