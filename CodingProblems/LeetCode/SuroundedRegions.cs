using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class SuroundedRegions
    {
        public class Solution
        {
            public static void Expand(int x, int y, char[,] board)
            {
                var toVisit = new Queue<Tuple<int, int>>();
                toVisit.Enqueue(new Tuple<int, int>(x, y));

                while (toVisit.Count > 0)
                {
                    var currentPos = toVisit.Dequeue();

                    if (board[currentPos.Item1, currentPos.Item2] == 'O')
                    {
                        board[currentPos.Item1, currentPos.Item2] = '1';

                        if (currentPos.Item1 > 0)
                        {
                            toVisit.Enqueue(new Tuple<int, int>(currentPos.Item1 - 1, currentPos.Item2));
                        }

                        if (currentPos.Item1 < board.GetLength(0) - 1)
                        {
                            toVisit.Enqueue(new Tuple<int, int>(currentPos.Item1 + 1, currentPos.Item2));
                        }

                        if (currentPos.Item2 > 0)
                        {
                            toVisit.Enqueue(new Tuple<int, int>(currentPos.Item1, currentPos.Item2 - 1));
                        }

                        if (currentPos.Item2 < board.GetLength(1) - 1)
                        {
                            toVisit.Enqueue(new Tuple<int, int>(currentPos.Item1, currentPos.Item2 + 1));
                        }
                    }
                }
            }

            public static void Solve(char[,] board)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    if (board[x, 0] == 'O')
                    {
                        Expand(x, 0, board);
                    }

                    if (board[x, board.GetLength(1) - 1] == 'O')
                    {
                        Expand(x, board.GetLength(1) - 1, board);
                    }
                }

                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[0, y] == 'O')
                    {
                        Expand(0, y, board);
                    }

                    if (board[board.GetLength(0) - 1, y] == 'O')
                    {
                        Expand(board.GetLength(0) - 1, y, board);
                    }
                }

                for (int x = 0; x < board.GetLength(0); x++)
                {
                    for (int y = 0; y < board.GetLength(1); y++)
                    {
                        if (board[x, y] == '1')
                        {
                            board[x, y] = 'O';
                        }
                        else if (board[x, y] == 'O')
                        {
                            board[x, y] = 'X';
                        }
                    }
                }
            }
        }
    }
}
