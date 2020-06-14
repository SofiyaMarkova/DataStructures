/*have 2D array of numbers:
start from top left corner and need to get to bottom right corner
what is the least sum it takes to get there.
so while each square gets visited its value gets added up to the total. need to find the path that will lead to the smallest sum

was solved with the concept of dynamic programming because
the solution involved asking each square individually what is the lowest sum to get to it.
building on that if each square knows to respond how much needs sum up to get to it,
the bottom right square from recursion can output a response
*/


using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sid
{
    class Program
    {

        static void Main(string[] args)
        {
            int[][] nums = new int[3][]; //declare array

//populate the rows
            for(int row = 0; row < nums.Length; row++)
            {
                nums[row] = new int[3];
            }
//populate array will be checking
            nums[0][0] = 1;
            nums[0][1] = 3;
            nums[0][2] = 1;
            nums[1][0] = 1;
            nums[1][1] = 5;
            nums[1][2] = 1;
            nums[2][0] = 4;
            nums[2][1] = 2;
            nums[2][2] = 1;

//call print function. inside it the function want to run is called with the outcome to be sent. so the answer to the ran function will be printed
            Console.WriteLine(minPathSum(nums));

        }

        static int minPathSum(int[][] grid)
        {
          //2 for loops to traverse 2D array
            for (int row = 0; row < grid.Length; row++)
            {
                for(int col = 0; col < grid[row].Length; col++)
                {
                    if(row == 0 && col == 0) //if in the [0,0] which is the starting point => there is nothing to check so it does continue and loops around with no action
                    {
                        continue;
                    }
                    int left = 100000; //set the above and left to very big numbers so the current value is always going to be smaller as to start (equivalent to infinity)
                    int above = 100000;

                    if(col != 0) //if column is not the 0 column means can check to the left of it still (0 col has no left to check, it is most left in array)
                    {
                        left = grid[row][col - 1]; //the left to compare is set to the one that is to the left of current square on
                    }
                    if(row != 0) //if row is not the 0 row means can check to the above of it still (0 row has no above to check, it is most above in array)
                    {
                        above = grid[row - 1][col];
                    }

                    int minimum = left; //sets the minium to left as if it is
                    if(above < minimum) //checks is maybe above is actually the smaller one
                    {
                        minimum = above; //if actually above is the smaller than above value is set to the minimum
                    }

                    grid[row][col] += minimum; //to the current square on add the minimum value (which is the min sum that it takes to get to the square from whatever direction makes min (that is irrelevant, just need number))
                }
            }

            return grid[grid.Length - 1][grid[0].Length - 1]; //recursively calls the function to return whatever again it needs to do to keep checking (until reach the end of the array: the bottom right corner ==> then it gives min value needed to get to it from all the sums before)
        }
    }
}
