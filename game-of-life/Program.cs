using System;

/*
    Rules of Game of Life 
    You start with a two dimensional grid of cells, where each cell is either alive or dead. 
    The grid is finite, and no life can exist off the edges. 

    When calculating the next generation of the grid, follow these four rules:
    1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.

    2. Any live cell with more than three live neighbours dies, as if by overcrowding.

    3. Any live cell with two or three live neighbours lives on to the next generation.

    4. Any dead cell with exactly three live neighbours becomes a live cell.

    EXAMPLE 1
    Example input:
    4 8
    ........
    ....*...
    ...**...
    .....*..

    Example output:
    4 8
    ........
    ...**...
    ...***..
    ....*...

    EXAMPLE 2
    Example input:
    5 8
    ........
    ...**...
    .*****..
    ........
    ........

    Example output:
    5 8
    ........
    .....*..
    ..*..*..
    ..***...
    ........    
*/

namespace game_of_life
{
    class Program
    {

        public int GetLiveNeighbourCount(int[,] mat, int numRow, int numCol, int row, int col)
        {
            int count = 0;

            // North cell
            if (row > 0 && mat[row - 1, col] == 1)
            {
                count += 1;
            }

            // South cell
            if (row < numRow - 1 && mat[row + 1, col] == 1)
            {
                count += 1;
            }

            //West
            if (col > 0 && mat[row, col - 1] == 1)
            {
                count += 1;
            }

            // East
            if (col < numCol - 1 && mat[row, col + 1] == 1)
            {
                count += 1;
            }

            // SE
            if (row < numRow - 1 && col < numCol - 1 && mat[row + 1, col + 1] == 1)
            {
                count += 1;
            }

            //NW
            if (col > 0 && row > 0 && mat[row - 1, col - 1] == 1)
            {
                count += 1;
            }

            // NE
            if (row > 0 && col < numCol - 1 && mat[row - 1, col + 1] == 1)
            {
                count += 1;
            }

            //SW
            if (col > 0 && row < numRow - 1 && mat[row + 1, col - 1] == 1)
            {
                count += 1;
            }

            return count;

        }

        public void Solve(int[,] mat)
        {
            int row = mat.GetLength(0);
            int col = mat.GetLength(1);

            int[,] result = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int liveNeighbours = GetLiveNeighbourCount(mat, row, col, i, j);

                    // for cell(i,j) if live neighbour count is fewer than 2 
                    // it gonna be dead 
                    if (liveNeighbours < 2)
                    {
                        result[i, j] = 0;
                    }
                    // 4. Any dead cell with exactly three live neighbours becomes a live cell.
                    else if (liveNeighbours == 3)
                    {
                        result[i, j] = 1;
                    }
                    // 2. Any live cell with more than three live neighbours dies, as if by overcrowding.
                    else if (liveNeighbours > 3)
                    {
                        result[i, j] = 0;
                    }
                    else
                    {
                        result[i, j] = mat[i, j];
                    }

                }
            }
        }

        public int[,] GetNewGen(int[,] mat, int row, int col)
        {
            int[,] result = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    // for cell(i,j) if live neighbour count is fewer than 2 
                    // it gonna be dead 
                    if (GetLiveNeighbourCount(mat, row, col, i, j) < 2)
                    {
                        result[i, j] = 0;
                    }
                    // 4. Any dead cell with exactly three live neighbours becomes a live cell.
                    else if (GetLiveNeighbourCount(mat, row, col, i, j) == 3)
                    {
                        result[i, j] = 1;
                    }
                    // 2. Any live cell with more than three live neighbours dies, as if by overcrowding.
                    else if (GetLiveNeighbourCount(mat, row, col, i, j) > 3)
                    {
                        result[i, j] = 0;
                    }
                    else
                    {
                        result[i, j] = mat[i, j];
                    }

                }
            }
            return result;
        }


        static void Main() {
            int[,] mat = new int[,] {
               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
           };

           for(int i = 0 ; i < mat.GetLength(0); i++) {
            for(int j = 0 ; j < mat.GetLength(1); j++) {
                Console.WriteLine(" " + mat[i,j] + " ");
            }
            Console.WriteLine();
           }

        }

    }
}