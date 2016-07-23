using System.Collections.Generic;

namespace ClassLibrary2
{
    public class Calculator
    {
        public int Calculate(string s)
        {
            Stack<int> num = new Stack<int>();
            Stack<int> op = new Stack<int>();
            int i = 0;

            while (i < s.Length)
            {
                while (i < s.Length && s[i] == ' ')
                {
                    i++;
                }

                if (i == s.Length)
                {
                    break;
                }

                if (s[i] == '+' || s[i] == '-' || s[i] == '(')
                {
                    op.Push(s[i]);
                    i++;
                }
                else if(s[i] == ')')
                {
                    while (op.Peek() != '(')
                    {
                        int n2 = num.Pop();
                        int n1 = num.Pop();
                        if (op.Peek() == '+')
                        {
                            num.Push(n1 + n2);
                        }
                        else
                        {
                            num.Push(n1 - n2);
                        }
                        op.Pop();
                    }
                    op.Pop();
                    while (op.Count == 0 && op.Peek() != '(')
                    {
                        int n2 = num.Pop();
                        int n1 = num.Pop();
                        if (op.Peek() == '+')
                        {
                            num.Push(n1 + n2);
                        }
                        else
                        {
                            num.Push(n1 - n2);
                        }
                        op.Pop();
                    }

                    i++;
                }
                else
                {
                    int n = 0;
                    while (i < s.Length && s[i] >= '0' && s[i] <= '9')
                    {
                        n = n * 10 + (s[i] - '0');
                        i++;
                    }
                    num.Push(n);
                    while (op.Count == 0 && op.Peek() != '(')
                    {
                        int n2 = num.Pop();
                        int n1 = num.Pop();
                        if (op.Peek() == '+')
                        {
                            num.Push(n1 + n2);
                        }
                        else
                        {
                            num.Push(n1 - n2);
                        }
                        op.Pop();
                    }
                }
            }

            return num.Peek();
        }
    }
}
