using System;
using System.IO;
using System.Linq;

namespace GameofLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 15, N = 15;

            // Initializing the grid.
            int[,] grid = new int[M, N];
            string[] last = File.ReadLines(@"C:\Users\Dell\Downloads\TestCase.txt").ToArray();

            int generation = Convert.ToInt32(last[0]);
            for (int gen0 = 1; gen0 < last.Length; gen0++)
            {
                string[] pos = last[gen0].Split(' ');
                grid[Convert.ToInt32(pos[0]), Convert.ToInt32(pos[1])] = 1;
            }

            int[,] future = nextGeneration(grid, M, N);

            for (int loopGen = 1; loopGen < generation; loopGen++)
            {
                future = nextGeneration(future, M, N);
            }
            DisplayGrid(future, M, N);
        }

        // Function to print next generation
        static int[,] nextGeneration(int[,] grid, int M, int N)
        {
            int[,] future = new int[M, N];

            // Loop through every cell
            for (int l = 1; l < M - 1; l++)
            {
                for (int m = 1; m < N - 1; m++)
                {

                    // finding no Of Neighbours
                    // that are alive
                    int aliveNeighbours = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                            aliveNeighbours += grid[l + i, m + j];

                    // The cell needs to be subtracted
                    // from its neighbours as it was
                    // counted before
                    aliveNeighbours -= grid[l, m];

                    // Implementing the Rules of Life

                    // Cell is lonely and dies
                    if ((grid[l, m] == 1) &&
                                (aliveNeighbours < 2))
                        future[l, m] = 0;

                    // Cell dies due to over population
                    else if ((grid[l, m] == 1) &&
                                (aliveNeighbours > 3))
                        future[l, m] = 0;

                    // A new cell is born
                    else if ((grid[l, m] == 0) &&
                                (aliveNeighbours == 3))
                        future[l, m] = 1;

                    // Remains the same
                    else
                        future[l, m] = grid[l, m];
                }
            }

            return future;
        }
        public static void DisplayGrid(int[,] future, int M, int N)
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (future[i, j] == 0)
                        Console.Write(".");
                    else
                        Console.Write(i + "," + j);
                }
                Console.WriteLine();
            }
        }
    }
}