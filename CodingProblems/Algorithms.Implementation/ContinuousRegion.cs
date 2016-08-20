using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    public class ContinuousRegion
    {
        private readonly int[,] _matrix;

        public ContinuousRegion(int[,] matrix)
        {
            _matrix = matrix;
        }

        public int Count()
        {
            var count = 0;

            for(var row = 0; row < _matrix.GetLength(0); row++)
            {
                for (var column = 0; column < _matrix.GetLength(1); column++)
                {
                    //we found a new region
                    if (_matrix[row, column] == 1)
                    {
                        //we need to DFS all direction and set the all the connected regions to 0
                        MarkRegion(row, column);
                        count++;
                    }
                }
            }

            return count;
        }

        private void MarkRegion(int row, int column)
        {
            _matrix[row, column] = 0;

            //mark the current cell as 0
            //then dfs only if the next cell is 1...this will also prevent back tracking

            if ((row > 0) && (_matrix[row - 1, column] == 1))
            {
                MarkRegion(row - 1, column);
            }
            if ((row < (_matrix.GetLength(0) - 1)) && (_matrix[row + 1, column] == 1))
            {
                MarkRegion(row + 1, column);
            }
            if ((column > 0) && (_matrix[row, column - 1] == 1))
            {
                MarkRegion(row, column - 1);
            }
            if ((column < (_matrix.GetLength(1) - 1)) && (_matrix[row, column + 1] == 1))
            {
                MarkRegion(row, column + 1);
            }
        }
    }
}
