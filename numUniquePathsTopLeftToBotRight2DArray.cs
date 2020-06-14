/*have 2D array:
want to find how many different ways can get from top left corner to bottom right corner

solved with dynamic programming because each individual square is asked
how many different ways can reach you. taking account coming from top and from left. (idea is combo of the minPathNumSum algorithm 
and the how many from each stair can get to the top if can do 1 step or 2 steps at a time)

*/
﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sid
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(uniquePaths(5, 3)); //pass in a 5 row, 3 col grid
        }

        static int uniquePaths(int m, int n)
        {

//makes the grid
            int[][] grid = new int[m][];

            for (int row = 0; row < grid.Length; row++)
            {
                grid[row] = new int[n];
            }

            grid[0][0] = 1;

//2 for loops traverse the 2D array grid
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (row == 0 && col == 0) //if row and col is 0 that is [0,0] there no point of checking. just loop again through
                    {
                        continue;
                    }

                    int left = 0; //set default to 0
                    int above = 0;

                    if (col != 0) //if column no 0
                    {
                        left = grid[row][col - 1]; //then set left to be the number that is left the current
                    }
                    if (row != 0) //if row not 0
                    {
                        above = grid[row - 1][col]; //set the above to be the number that is above the current
                    }

                    //add the values from above and left to the current
                    grid[row][col] = above + left;

                }
            }



            return grid[grid.Length - 1][grid[0].Length - 1]; //recursively run again now moving to the next right and down progressively through all 2D array


        }
    }
}
