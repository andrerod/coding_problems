using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    public class Stack
    {

        #region Min Stack - 2 stacks

        public class MinStack
        {
            private Stack<int> stack = new Stack<int>();
            private Stack<int> minStack = new Stack<int>();

            public void Push(int value)
            {
                stack.Push(value);
                if (minStack.Count == 0 || value <= minStack.Peek())
                {
                    minStack.Push(value);
                }
            }

            public int Pop()
            {
                if (stack.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                int value = stack.Pop();
                if (value == minStack.Peek())
                {
                    minStack.Pop();
                }
                return value;
            }

            public int GetMin()
            {
                if (minStack.Count == 0)
                {
                    throw new InvalidOperationException();
                }
                return minStack.Peek();
            }

        }

        #endregion

        #region Min Stack - Constant Space

        public class MinStackConstantSpace
        {

            private Stack<int> stack = new Stack<int>();
            private int min = int.MaxValue;

            public void Push(int value)
            {
                stack.Push(value - min);
                if (value < min)
                {
                    min = value;
                }
            }

            public int Pop()
            {
                if (stack.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                int currentMin = min;
                int diff = stack.Pop();

                if (diff < 0)
                {
                    min = currentMin - diff;
                }

                return diff + min;
            }

            public int GetMin()
            {
                if (stack.Count == 0)
                {
                    throw new InvalidOperationException();
                }
                return min;
            }

        }

        #endregion

        #region Balanced Parentheses

        /// <summary>
        /// Check is parentheses are balanced
        /// 
        /// ((())) is balanced
        /// )( is not balanced
        /// </summary>
        /// <param name="parantheses"></param>
        /// <returns></returns>
        public static bool BalancedParentheses(string parantheses)
        {
            Stack<char> tracker = new Stack<char>();

            foreach (char character in parantheses)
            {
                if (character == '(')
                {
                    tracker.Push(character);
                }
                else
                {
                    if (tracker.Count == 0)
                    {
                        return false;
                    }

                    char existingCharacter = tracker.Pop();

                    if (existingCharacter != '(')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Check is parentheses are balanced
        /// 
        /// Support (, {, [
        /// </summary>
        /// <param name="parantheses"></param>
        /// <returns></returns>
        public static bool BalancedParenthesesMultiple(string parantheses)
        {
            Dictionary<char, char> bracketMatch = new Dictionary<char, char> {
                {')', '('},
                {']', '['},
                {'}', '{'},
            };

            Stack<char> tracker = new Stack<char>();

            foreach (char character in parantheses)
            {
                if ((character == '(') || (character == '[') || (character == '{'))
                {
                    tracker.Push(character);
                }
                else
                {
                    if (tracker.Count == 0)
                    {
                        return false;
                    }

                    char existingCharacter = tracker.Pop();

                    if (existingCharacter != bracketMatch[character])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Use a variable s to denote the start of the valid pattern
        /// 
        /// when we encounter ) at index i, there are 3 cases:
        ///     1. stack is empty - no valid pattern, s = i + 1
        ///     2. stack has 1 element - we found the end of a pattern...calculate length as i - s + 1...and compare to max
        ///     3. stack has multiple elements - since all patterns from the top of the stack (only invalid is many ')'), meaning stack would be empty,
        ///        length is i - s.top...only if we push index into s
        /// </summary>
        /// <param name="parantheses"></param>
        /// <returns></returns>
        public static int LengthOfLongestBalancedParanthese(string parantheses)
        {
            int max = 0;
            int start = 0;
            Stack<int> tracker = new Stack<int>();

            for (int index = 0; index < parantheses.Length; index++)
            {
                char chr = parantheses[index];
                if (chr == '(')
                {
                    tracker.Push(index);
                }
                else
                {
                    if (tracker.Count == 0)
                    {
                        //invalid pattern...case 1
                        start = index + 1;
                    }
                    else
                    {
                        tracker.Pop();
                        if (tracker.Count == 0)
                        {
                            //case 2
                            max = System.Math.Max(max, index - start + 1);
                        }
                        else
                        {
                            //sub pattern...if everything afterward is invalid or we run out of closing brackets, this could be longest
                            //case 3
                            //(((()())
                            //   _)
                            //   ___)
                            //  _____)
                            max = System.Math.Max(max, index - tracker.Peek());
                        }
                    }
                }
            }

            return max;
        }

        #endregion

        #region Reverse Polish Notation

        /// <summary>
        /// Valid operators are +, -, *, /. Each operand may be an integer or another expression.
        /// 
        /// ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
        /// ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public static int EvalRPN(string[] tokens)
        {
            if (tokens == null)
            {
                throw new ArgumentException();
            }

            if (tokens.Length == 0)
            {
                return 0;
            }

            //looks like we only need to look back 2 when we encounter an operator
            //what if we push into stack, pop 2 if we encounter an operator, evaluate it
            //and push it back until we encounter another symbol
            //if we are done, just pop the final result from the stack

            //in case of an overflow
            Stack<long> stack = new Stack<long>();
            foreach (string token in tokens)
            {
                if ((token == "+") || (token == "-") || (token == "*") || (token == "/"))
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException();
                    }

                    long right = stack.Pop();
                    long left = stack.Pop();

                    long result = 0;
                    switch (token)
                    {
                        case "+":
                            result = left + right;
                            break;
                        case "-":
                            result = left - right;
                            break;
                        case "*":
                            result = left * right;
                            break;
                        case "/":
                            result = left / right;
                            break;
                    }
                    stack.Push(result);
                }
                else
                {
                    stack.Push(long.Parse(token));
                }
            }

            if (stack.Count == 1)
            {
                return (int)stack.Pop();
            }

            throw new ArgumentException();
        }

        #endregion

    }
}
