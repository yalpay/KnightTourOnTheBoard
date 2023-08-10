using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Program
{

    /// <summary>
    /// In this class Warnsdorff's algortihm implemented. this algortihm is not efficient as the number of size of the 
    /// board increases. Another algotihm is explained in: https://www.youtube.com/watch?v=9fSFC00ZKPg
    /// For more algortihms and different approaches for this problem: http://www.mayhematics.com/t/t.htm
    /// A nice game on: http://www.maths-resources.com/knights/
    /// </summary>
    public static class WithoutGUI
    {
        private static int _outerSize;
        readonly static int[,] _moves = { {+1,-2},{+2,-1},{+2,+1},{+1,+2},{-1,+2},{-2,+1},{-2,-1},{-1,-2} };
        private static int[,] _grid;
        private static int _total;

        public static void Main(string[] args)
        {
            // for each starting point on the board, generate a solution..
            _outerSize = 12;
            var dt = DateTime.Now;
            RunFromStart(3, 5, _outerSize);
            Console.WriteLine(DateTime.Now - dt);
            

            // CreateSolution();
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        /// <summary>
        /// You can call this method to create solution for each point on the board
        /// </summary>
        private static void CreateSolution()
        {
            for (int row = 2; row < _outerSize - 2; row++)
                for (int col = 2; col < _outerSize - 2; col++)
                    RunFromStart(row, col, _outerSize);
        }
        public static void RunFromStart(int row, int col, int size)
        {
            // initialize board and settings
            _grid = new int[_outerSize, _outerSize];
            _total = (_outerSize - 4) * (_outerSize - 4);

            for (int r = 0; r < _outerSize; r++)
                for (int c = 0; c < _outerSize; c++)
                    if (r < 2 || r > _outerSize - 3 || c < 2 || c > _outerSize - 3)
                        _grid[r, c] = -1;

            _grid[row, col] = 1;   // starting point
            string text = "";

            if (Solve(row, col, 2))  // recursive function
                text = PrintResult();
            else
                text = "No result found";

            var path = @"C:\Users\yasin\OneDrive\Masaüstü\AkınSoftChessApp\Outputs\data" + row + "_" + col + ".txt";
            File.WriteAllText(path, text);
        }

        // returns the matrix to be printed to specified path
        private static string PrintResult()
        {
            var output = "";
            for (int i = 2; i < _outerSize - 2; i++)
            {
                for (int j = 2; j < _outerSize - 2; j++)
                    output += _grid[i,j] + "      ";
                output += "\n\n";
            }
            return output;
        }

        /// <summary>
        /// completes the tour by Warnsdorff's rule. The knight is moved so that it always proceeds to 
        /// the square from which the knight will have the fewest onward moves.
        /// visit for more information: https://en.wikipedia.org/wiki/Knight%27s_tour
        /// solution for Java with this algorithm: https://www.geeksforgeeks.org/warnsdorffs-algorithm-knights-tour-problem/
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private static bool Solve(int r, int c, int count)
        {
            if (count > _total)
                return true;

            List<int[]> nbrs = Neighbors(r, c);

            if (!nbrs.Any() && count != _total)
                return false;

            nbrs.OrderBy(n => n[2]);
            for (int i = 0; i < nbrs.Count; i++)
            {
                r = nbrs[i][0];
                c = nbrs[i][1];
                _grid[r,c] = count;
                if (!DeadEndDetected(count, r, c) && Solve(r, c, count + 1))
                    return true;
                _grid[r,c] = 0;
            }
            return false;
        }
 
        /// <summary>
        /// returns the legal moves for a knight 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static List<int[]> Neighbors(int r, int c)
        {
            List<int[]> nbrs = new List<int[]>();

            for (int i = 0; i < _moves.GetLength(0); i++)
            {
                int x = _moves[i, 0];
                int y = _moves[i, 1];
                if (_grid[r + y, c + x] == 0)
                {
                    int num = CountNeighbors(r + y, c + x);
                    nbrs.Add(new int[] { r + y, c + x, num });
                }
            }
            return nbrs;
        }

        /// <summary>
        /// returns the numbers of legal moves, neighbors on the real board that is not visited before
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static int CountNeighbors(int r, int c)
        {
            int num = 0;
            for (int i = 0; i < _moves.GetLength(0); i++)
                if (_grid[r + _moves[i, 1], c + _moves[i, 0]] == 0)
                    num++;
            return num;
        }

        /// <summary>
        /// if this method returns false, solve method runs backwards until it finds a path
        /// </summary>
        /// <param name="cnt"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool DeadEndDetected(int cnt, int r, int c)
        {
            if (cnt < _total - 1)
            {
                List<int[]> nbrs = Neighbors(r, c);
                for (int i = 0; i < nbrs.Count; i++)
                    if (CountNeighbors(nbrs[i][0], nbrs[i][1]) == 0)
                        return true;
            }
            return false;
        }

        public static Tuple<int, int> CoordinatesOf<T>(this T[,] matrix, T value)
        {
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }

    }
}