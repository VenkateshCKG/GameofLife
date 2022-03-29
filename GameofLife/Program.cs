using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GameofLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\netcoreapp3.1", string.Empty));
            string pathTestCase1 = @"TestCases\TestCase1.txt";
            var location = Path.Combine(basePath, pathTestCase1);
            Console.WriteLine(FindGeneration(location));
        }

        public static string FindGeneration(string path)
        {
            int M = 15, N = 15;

            // Initializing the grid.
            int[,] grid = new int[M, N];
            string[] last = File.ReadLines(path).ToArray();

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
            return DisplayGrid(future, M, N);
        }

        // Function to print next generation
        public static int[,] nextGeneration(int[,] grid, int M, int N)
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
                    if ((grid[l, m] == 1) && (aliveNeighbours < 2))
                        future[l, m] = 0;

                    // Cell dies due to over population
                    else if ((grid[l, m] == 1) && (aliveNeighbours > 3))
                        future[l, m] = 0;

                    // A new cell is born
                    else if ((grid[l, m] == 0) && (aliveNeighbours == 3))
                        future[l, m] = 1;

                    // Remains the same
                    else
                        future[l, m] = grid[l, m];
                }
            }

            return future;
        }
        public static string DisplayGrid(int[,] future, int M, int N)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (future[i, j] == 1)
                        result.Append($"({i},{j}),");
                }
            }
            return $"[{result.ToString().Trim(',')}]";
        }
    }
}

