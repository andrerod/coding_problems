using Algorithms.Implementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{

    public class BinaryTree<T>
    {

        public TreeNode<T> Root { get; set; }

        #region Traversal

        public List<T> InOrderIterative()
        {
            List<T> result = new List<T>();
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            TreeNode<T> current = this.Root;

            while (true)
            {
                if (current != null)
                {
                    //there is a left node...later this will also add right side node
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    //we are done traversing to left...pop and start processing

                    //terminal condition...if stack is empty...we are done
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        current = stack.Pop();
                        
                        //do something with current...
                        result.Add(current.Value);

                        //set any right side node for processing
                        current = current.Right;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// similar trick as in-order using current
        /// </summary>
        /// <returns></returns>
        public List<T> PostOrderIterative()
        {
            List<T> result = new List<T>();
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            TreeNode<T> current = this.Root;

            while (true)
            {
                if (current != null)
                {
                    //check if there is a right node of current, if so push right and then current
                    if (current.Right != null)
                    {
                        stack.Push(current.Right);
                    }
                    stack.Push(current);

                    current = current.Left;
                }
                else
                {
                    //we are done traversing to left...pop and start processing

                    //terminal condition...if stack is empty...we are done
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        current = stack.Pop();

                        if ((current.Right != null) && (stack.Count > 0) && (current.Right.Equals(stack.Peek())))
                        {
                            //if this right is already in the stack, we need to switch the root with right side, so we can
                            //process right side first
                            TreeNode<T> right = stack.Pop();
                            stack.Push(current);
                            current = right;
                        }
                        else
                        {
                            //do something with current...
                            result.Add(current.Value);
                            current = null;
                        }
                    }
                }
            }

            return result;
        }

        public List<T> PreOrderIterative()
        {
            List<T> result = new List<T>();
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(this.Root);

            while (stack.Count > 0)
            {
                TreeNode<T> node = stack.Pop();

                //do current processing
                result.Add(node.Value);

                //since we are using stack, we want to push right side first
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }

            return result;
        }

        #endregion

        #region Level & ZigZag

        /// <summary>
        ///          1
        ///         / \
        ///        3   5
        ///       / \   \
        ///      2   4   7
        ///     /     \
        ///    9       8
        /// 
        /// Expected output:
        ///   1
        ///   3 5
        ///   2 4 7
        ///   9 8
        ///   
        /// Use a sentinel node when parsing nodes into the queue
        /// If sentinel node is encountered, put another one (we parsed
        /// all previous level) and end the level
        /// </summary>
        /// <returns></returns>
        public List<List<T>> BFSWithLevel()
        {
            List<List<T>> result = new List<List<T>>();

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(this.Root);

            //put sentinel
            queue.Enqueue(new SentinelTreeNode<T>());

            List<T> level = new List<T>();
            while (queue.Count > 0)
            {
                TreeNode<T> node = queue.Dequeue();

                //if we don't check for count, we keep repeating sentinel node
                //since if the last node is sentinel we just put it right back
                if ((node is SentinelTreeNode<T>) && (level.Count > 0))
                {
                    //we encountered a sentinel node which means we are done processing previous level
                    result.Add(level);

                    //reinitialize level
                    level = new List<T>();

                    //requeue the sentinel node
                    queue.Enqueue(node);
                }
                else
                {
                    //normal nodes, do BFS
                    level.Add(node.Value);

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
            }

            return result;
        }

        public List<List<T>> BFSWithLevelRecursion()
        {
            List<List<T>> result = new List<List<T>>();

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this.Root);

            this.BFSWithLevelRecursion(result, queue);

            return result;
        }

        private void BFSWithLevelRecursion(List<List<T>> result, Queue<TreeNode<T>> queue)
        {
            Queue<TreeNode<T>> lowerLevel = new Queue<TreeNode<T>>();

            List<T> level = new List<T>();
            foreach(TreeNode<T> node in queue) {
                if (node.Left != null)
                {
                    lowerLevel.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    lowerLevel.Enqueue(node.Right);
                }

                level.Add(node.Value);
            }

            result.Add(level);

            if (lowerLevel.Count > 0)
            {
                BFSWithLevelRecursion(result, lowerLevel);
            }
        }

        public List<List<T>> BFSWithLevelIterative()
        {
            List<List<T>> result = new List<List<T>>();

            Queue<TreeNode<T>> temp;
            Queue<TreeNode<T>> current = new Queue<TreeNode<T>>();
            Queue<TreeNode<T>> next = new Queue<TreeNode<T>>();
            current.Enqueue(this.Root);

            while (current.Count > 0)
            {
                List<T> level = new List<T>();

                while (current.Count > 0)
                {
                    TreeNode<T> node = current.Dequeue();
                    
                    //process level logic
                    level.Add(node.Value);

                    if (node.Left != null)
                    {
                        next.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        next.Enqueue(node.Right);
                    }
                }

                //process end of level logic
                result.Add(level);

                //switch queues
                temp = current;
                current = next;
                next = temp;
            }

            return result;
        }

        public List<List<T>> LevelZigZagRecursive()
        {
            List<List<T>> result = new List<List<T>>();

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(this.Root);

            this.LevelZigZagRecursive(result, stack, false);

            return result;
        }

        private void LevelZigZagRecursive(List<List<T>> result, Stack<TreeNode<T>> stack, bool leftFirst)
        {
            Stack<TreeNode<T>> lowerLevel = new Stack<TreeNode<T>>();

            List<T> level = new List<T>();
            
            while(stack.Count > 0)
            {
                TreeNode<T> node = stack.Pop();
                
                TreeNode<T> newFirstNode = (leftFirst) ? node.Left : node.Right;
                TreeNode<T> newSecondNode = (leftFirst) ? node.Right : node.Left;
                
                if (newFirstNode != null)
                {
                    lowerLevel.Push(newFirstNode);
                }
                if (newSecondNode != null)
                {
                    lowerLevel.Push(newSecondNode);
                }

                level.Add(node.Value);
            }

            result.Add(level);

            if (lowerLevel.Count > 0)
            {
                LevelZigZagRecursive(result, lowerLevel, !leftFirst);
            }
        }

        public List<List<T>> LevelZigZagIterative()
        {
            List<List<T>> result = new List<List<T>>();

            Stack<TreeNode<T>> temp;
            Stack<TreeNode<T>> current = new Stack<TreeNode<T>>();
            Stack<TreeNode<T>> next = new Stack<TreeNode<T>>();
            current.Push(this.Root);

            bool scanLeft = false;

            while (current.Count > 0)
            {
                List<T> level = new List<T>();

                while (current.Count > 0)
                {
                    TreeNode<T> node = current.Pop();

                    //process level logic
                    level.Add(node.Value);

                    //if we scan left, it will process right to left since we are using stack
                    TreeNode<T> firstNode = (scanLeft) ? node.Left : node.Right;
                    TreeNode<T> secondNode = (scanLeft) ? node.Right : node.Left;
                    if (firstNode != null)
                    {
                        next.Push(firstNode);
                    }
                    if (secondNode != null)
                    {
                        next.Push(secondNode);
                    }
                }

                //process end of level logic
                result.Add(level);

                //switch stack & direction
                temp = current;
                current = next;
                next = temp;
                scanLeft = !scanLeft;
            }

            return result;
        }

        #endregion

        #region Iterative Deepening

        /// <summary>
        /// This is a technique where we perform depth bound DFS to simulate BFS
        /// The traversal pattern is like BFS so we can find things quickly but the space usage is like DFS
        /// where the queue doesn't grow exponentially with each depth
        /// 
        ///           A
        ///        B     C
        ///     D    EF      G
        /// 
        /// 1. A
        /// 2. A B C
        /// 3. A B D E C F G
        /// </summary>
        /// <returns></returns>
        public List<List<T>> LevelWithIterativeDeepening()
        {
            List<List<T>> result = new List<List<T>>();
            
            int depth = 0;
            while (result.Count == depth)
            {
                depth++;
                this.IDDfs(result, this.Root, 1, depth);
            }

            return result;
        }
        
        private void IDDfs(List<List<T>> result, TreeNode<T> node, int currentDepth, int bound)
        {
            if ((currentDepth > bound) || (node == null))
            {
                return;
            }

            if (node.Left != null)
            {
                this.IDDfs(result, node.Left, currentDepth + 1, bound);
            }

            if (currentDepth == bound)
            {
                if (result.Count < currentDepth)
                {
                    result.Add(new List<T>());
                }
                result[currentDepth - 1].Add(node.Value);
            }

            if (node.Right != null)
            {
                this.IDDfs(result, node.Right, currentDepth + 1, bound);
            }
        }

        #endregion

        #region Max Depth

        /// <summary>
        /// Return the maximum depth of a binary tree
        /// 
        /// Should just do bfs with count incremented every level
        /// 
        /// return count if no other child to traverse
        /// </summary>
        /// <returns></returns>
        public int MaxDepthBFS()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this.Root);

            return MaxDepthBFS(queue, 0);
        }

        private int MaxDepthBFS(Queue<TreeNode<T>> queue, int level)
        {
            if (queue.Count == 0)
            {
                return level;
            }

            Queue<TreeNode<T>> nextLevel = new Queue<TreeNode<T>>();
            foreach (TreeNode<T> node in queue)
            {
                if (node.Left != null)
                {
                    nextLevel.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    nextLevel.Enqueue(node.Right);
                }
            }

            return MaxDepthBFS(nextLevel, level + 1);
        }

        public int MaxDepthDFS()
        {
            return this.MaxDepthDFS(this.Root, 1);
        }

        private int MaxDepthDFS(TreeNode<T> node, int level)
        {
            //if leaf node, return the level
            if ((node.Left == null) && (node.Right == null))
            {
                return level;
            }

            int newLevel = level;

            if (node.Left != null)
            {
                newLevel = System.Math.Max(newLevel, this.MaxDepthDFS(node.Left, level + 1));
            }
            if (node.Right != null)
            {
                newLevel = System.Math.Max(newLevel, this.MaxDepthDFS(node.Right, level + 1));
            }

            return newLevel;
        }

        #endregion

        #region Least Common Ancestor

        /// <summary>
        ///          1
        ///         / \
        ///        3   5
        ///       / \   \
        ///      2   4   7
        ///     /     \
        ///    9       8
        ///    
        /// Expected output:
        ///   2, 5 => 1
        ///   2, 9 => 3
        ///   
        /// Perform post order DFS with count, if count is two, then we have found it. 
        /// There are two cases
        ///     When we get match from each sub tree
        ///     When both are in the same sub tree, doing post order will ensure that it finds the ancestor not itself
        public T LeastCommonAncestor(T val1, T val2)
        {
            T leastCommonAncestor = default(T);

            int count = this.LeastCommonAncestor(this.Root, val1, val2, ref leastCommonAncestor);

            if ((count == 2) && (!leastCommonAncestor.Equals(default(T))))
            {
                //we found it
                return leastCommonAncestor;
            }

            //cannot find one maybe nodes are not valid
            throw new ArgumentException();
        }

        private int LeastCommonAncestor(TreeNode<T> node, T val1, T val2, ref T leastCommonAncestor)
        {
            int count = 0;

            if (node.Left != null)
            {
                count += this.LeastCommonAncestor(node.Left, val1, val2, ref leastCommonAncestor);
            }
            if (node.Right != null)
            {
                count += this.LeastCommonAncestor(node.Right, val1, val2, ref leastCommonAncestor);
            }

            //if we assume no duplicate, we will never find more than 2 so it's sufficient to check only once here
            if ((count == 2) && (leastCommonAncestor.Equals(default(T))))
            {
                //also make sure we check is leastCommonAncestor is not set, otherwise we will keep overriding it
                leastCommonAncestor = node.Value;
            }

            //now check for self
            if ((node.Value.Equals(val1)) || (node.Value.Equals(val2)))
            {
                count++;
            }

            return count;
        }

        #endregion

        #region Lowest Common Ancestor With Parent

        /// <summary>
        ///         _______3______
        ///        /              \
        ///     ___5__          ___1__
        ///    /      \        /      \
        ///    6      _2       0       8
        ///          /  \
        ///          7   4
        ///          
        /// 5 & 1 = 3
        /// 5 & 4 = 5
        /// 
        /// Using a dictionary, track visited nodes
        /// Move one parent by one parent, and see if current parent is in the tracker
        /// First encountered parent is the LCA
        /// 
        /// 
        /// More clever solution not using a dictionary is figure out the height difference
        /// If we eliminate the height different (by fast forwarding the lower level one towards the root)
        /// we just need to move both nodes one by one and they will at the LCA
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int LowestCommonAncestorParent(TreeNode<int> left, TreeNode<int> right)
        {
            Dictionary<int, int> tracker = new Dictionary<int, int>();
            tracker.Add(left.Value, left.Value);
            tracker.Add(right.Value, right.Value);

            while ((left != null) || (right != null))
            {
                if (left != null)
                {
                    if (left.Parent != null) 
                    {
                        if (tracker.ContainsKey(left.Parent.Value)) {
                            return left.Parent.Value;
                        }
                        else {
                            tracker.Add(left.Parent.Value, left.Parent.Value);
                        }
                    }
                    left = left.Parent;
                }
                if (right != null)
                {
                    if (right.Parent != null)
                    {
                        if (tracker.ContainsKey(right.Parent.Value))
                        {
                            return right.Parent.Value;
                        }
                        else
                        {
                            tracker.Add(right.Parent.Value, right.Parent.Value);
                        }
                    }
                    right = right.Parent;
                }
            }

            throw new Exception("No LCA");
        }

        #endregion

        #region Diameter (Longest path)

        /// <summary>
        /// Diameter of a binary tree is the longest path between two leaf nodes
        /// It could go through the root or may not
        /// 
        ///             7                       7
        ///              L                      N
        ///          L      L               L       N
        ///        L   N   N  L          L     L
        ///      L              L      L         L
        ///                               L         L
        ///                               
        /// For a given sub tree, the longest path is the max of the following
        ///     Diameter of left (this is the case in second where left sub tree contains the longest diameter which isn't shown by height
        ///     Diameter of right
        ///     Combined left + right height + 1  (this is the case in first where the left and right sides form the longest)
        /// </summary>
        /// <returns></returns>
        public int Diameter()
        {
            return this.Diameter(this.Root);
        }

        private int Diameter(TreeNode<T> node)
        {
            int leftDiameter = (node.Left != null) ? this.Diameter(node.Left) : 0;
            int rightDiameter = (node.Right != null) ? this.Diameter(node.Right) : 0;
            int leftHeight = (node.Left != null) ? this.Height(node.Left) : 0;
            int rightHeight = (node.Right != null) ? this.Height(node.Right) : 0;

            return System.Math.Max(leftHeight + rightHeight + 1, System.Math.Max(leftDiameter, rightDiameter));
        }

        /// <summary>
        /// Height of a tree is calculated by 1 + max (left height, right height)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int Height(TreeNode<T> node)
        {
            int leftHeight = (node.Left != null) ? this.Height(node.Left) : 0;
            int rightHeight = (node.Right != null) ? this.Height(node.Right) : 0;

            return 1 + System.Math.Max(leftHeight, rightHeight);
        }

        #endregion

        #region Balanced Tree

        public bool IsBalanced()
        {
            if (this.Root == null)
            {
                return true;
            }

            //since it requires every node to only differ by one (not all leaf nodes), 
            //we need to recursively compare left and right height of every sub tree
            return IsBalanced(this.Root) != -1;
        }

        private int IsBalanced(TreeNode<T> node)
        {
            int left = (node.Left != null) ? IsBalanced(node.Left) : 0;
            int right = (node.Right != null) ? IsBalanced(node.Right) : 0;

            if ((left == -1) || (right == -1) || (System.Math.Abs(left - right) > 1))
            {
                return -1;
            }

            return System.Math.Max(left, right) + 1;
        }

        #endregion


    }

}
