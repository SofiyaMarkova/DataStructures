/*
in a 2D array of 1s and 0s. find the amount of "islands"
where an "island" is a group of 1s with 0s around it

using the method of a DFS for when a 1 is found to find all the paths around the 1 where there are other 1s.
changes all the found 1s of the island to a 0 so that it does not count it again after

loops thorugh the whole array to find all the islands and prints the amount of islands found

*/

using System;
using System.Collections.Generic;

namespace TestFunctionCall
{
    class Program
    {
        static void Main(string[] args)
        {
//creating array to pass
            int[,] grid = new int[4, 4];
            grid[0, 0] = 1;
            grid[1, 0] = 1;
            grid[1, 1] = 1;
            grid[0, 3] = 1;
            grid[1, 3] = 1;
            grid[3, 0] = 1;
//calling the function while passing the created grid array
            int n = CountIslands(grid);
            //printing outcome of function (will print the number of islands)
            Console.WriteLine(n);
        }

        //do not need to make a Node class because the grid positions in themselves act as nodes. so realtive to them and on them do operations

        //grid.GetLength(0) ==> gets length at 0 dimension, grid.GetLength(1) ==> gets lenth at 1 dimension. because special array. regular arry grid.length and grid[0].length would work
        static int CountIslands(int[,] grid)
        {
            int islands = 0; //set island count to 0, declare the var that will keep track of it

            //to keep traversing grid. by row and col as it looks for 1 and then does the operation
            for (int gridRow = 0; gridRow < grid.GetLength(0); gridRow++)
            {

                for (int gridCol = 0; gridCol < grid.GetLength(1); gridCol++)
                {

                    if (grid[gridRow, gridCol] == 1)
                    {

                        Queue<int[]> queue = new Queue<int[]>();//make stack to stack on for DFS (called Queue but logically a stack)
                        queue.Enqueue(new int[] { gridRow, gridCol }); //add the grid point working on to the stack

//keep checking until the stack is empty
                        while (queue.Count > 0)
                        {

                            int[] currNode = queue.Dequeue(); //DFS so staying on last (top of stack) so not keep checking same one
                            int row = currNode[0]; //"0th dimension" of array object ==> the row like
                            int col = currNode[1]; //"1st dimension" of array object ==> the col like

                            //checks each square around. will add to stack if there is a 1 on a square next to square on
                            if (row - 1 > 0 && grid[row - 1, col] != 0)
                            {
                                grid[row - 1, col] = 0; //set to 0 to not have to check again
                                queue.Enqueue(new int[] { row - 1, col }); //add to top of stack
                            }
                            if (row + 1 < grid.GetLength(0) && grid[row + 1, col] != 0)
                            {
                                grid[row + 1, col] = 0;
                                queue.Enqueue(new int[] { row + 1, col });
                            }
                            if (col - 1 > 0 && grid[row, col - 1] != 0)
                            {
                                grid[row, col - 1] = 0;
                                queue.Enqueue(new int[] { row, col - 1});
                            }
                            if (col + 1 < grid.GetLength(1) && grid[row, col + 1] != 0)
                            {
                                grid[row, col + 1] = 0;
                                queue.Enqueue(new int[] { row, col + 1});
                            }
                        }

                        islands++; //if it did end up going into this loop it means that it found an island (and was trying to find all the parts of the island to replace with 0)
//but after it found the island and all, it will count that island ++
                    }

                }

            }

            return islands; //the function returns to print the number of islands found after all the going through array
        }
    }
}
