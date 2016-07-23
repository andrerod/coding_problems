using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class SudokuSolver
    {
        public bool IsValid(int x, int y, char[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != y && board[x, i] == board[x,y] || x != i && board[i, y] == board[x, y])
                {
                    return false;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[x / 3 * 3 + i, y / 3 * 3 + j] == board[x, y] && x != x / 3 * 3 + i && y != y / 3 * 3 + j)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void SolveSudoku(char[,] board)
        {
            Solve(board);
        }

        public bool Solve(char[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i,j] == '.')
                    {

                        for (int k = 0; k < 9; k++)
                        {
                            board[i, j] = (char)('1' + k);
                            if (!IsValid(i, j, board) && Solve(board)) return true;
                            board[i, j] = '.';
                        }
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
