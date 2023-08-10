// C# program for  
// Knight Tour problem 
// taken from https://www.geeksforgeeks.org/the-knights-tour-problem-backtracking-1/
using System;

class GFG
{
    static int N;
    static int m;
    /* A utility function to  
    check if i,j are valid  
    indexes for N*N chessboard */
    static bool isSafe(int x, int y,
                       int[,] sol)
    {
        return (x >= 0 && x < N &&
                y >= 0 && y < N &&
                sol[x, y] == -1);
    }

    /* A utility function to  
    print solution matrix sol[N][N] */
    static void printSolution(int[,] sol)
    {
        for (int x = 0; x < N; x++)
        {
            for (int y = 0; y < N; y++)
                Console.Write(sol[x, y] < 10 ? sol[x, y] + "\t " : sol[x, y] + "\t");
            Console.WriteLine("\n\n");
        }
    }

    /* This function solves the  
    Knight Tour problem using  
    Backtracking. This function  
    mainly uses solveKTUtil() to  
    solve the problem. It returns  
    false if no complete tour is  
    possible, otherwise return true  
    and prints the tour. Please note  
    that there may be more than one  
    solutions, this function prints  
    one of the feasible solutions. */
    static bool solveKT(int startRow, int startCol)
    {        
        int[,] sol = new int[N, N];

        /* Initialization of 
        solution matrix */
        for (int x = 0; x < N; x++)
            for (int y = 0; y < N; y++)
                sol[x, y] = -1;

        /* xMove[] and yMove[] define 
           next move of Knight. 
           xMove[] is for next  
           value of x coordinate 
           yMove[] is for next  
           value of y coordinate */
        int[] xMove = {2, 1, -1, -2,
                      -2, -1, 1, 2};
        int[] yMove = {1, 2, 2, 1,
                      -1, -2, -2, -1};

        // Since the Knight is  
        // initially at the first block 
        sol[startRow, startCol] = 0;

        /* Start from 0,0 and explore  
        all tours using solveKTUtil() */
        if (!solveKTUtil(startRow, startCol, 1, sol,
                         xMove, yMove))
        {
            Console.WriteLine("Solution does " +
                                  "not exist");
            return false;
        }
        else
            printSolution(sol);

        return true;
    }

    /* A recursive utility function  
    to solve Knight Tour problem */
    static bool solveKTUtil(int x, int y, int movei,
                            int[,] sol, int[] xMove,
                            int[] yMove)
    {
        int k, next_x, next_y;
        if (movei == N * N)
            return true;
        Console.WriteLine(m++);
        /* Try all next moves from  
        the current coordinate x, y */
        for (k = 0; k < 8; k++)
        {
            next_x = x + xMove[k];
            next_y = y + yMove[k];
            if (isSafe(next_x, next_y, sol))
            {
                sol[next_x, next_y] = movei;
                if (solveKTUtil(next_x, next_y, movei +
                                 1, sol, xMove, yMove))
                    return true;
                else
                    // backtracking 
                    sol[next_x, next_y] = -1;
            }
        }

        return false;
    }

    // Driver Code 
    public static void Main()
    {
        m = 0;
        N = 5;
        var dt = DateTime.Now;
        solveKT(3,3);
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadLine();
    }
}

// This code is contributed by mits. 