/*using Breadth First Search

have 2D array.
certain square is where start (2) and certain square is where want to get to (1).

square with 0 is can go
square with 3 is can't go (obstacle)

want to see:

- what path to take to get there
- if first off possible to get there (2nd method with 3 being checked because it may be blocking)

*/

﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sid
{
    class Node
    {
//set var to use. pubic so always can access in any object
        public int val;
        public int row;
        public int col;

//creating a node. that knows: what val it stores, what row it on, what col it on
        public Node(int val, int row, int col)
        {
            this.val = val;
            this.row = row;
            this.col = col;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Node[,] grid = new Node[5, 5]; //[,] is same as [][]

//making the grid
            for(int row = 0; row < 5; row++)
            {
                for(int col = 0; col < 5; col++)
                {
                    grid[row, col] = new Node(0, row, col);
                }
            }

//makeing the grid so grid[#,#] stores the value as 2D array is. but the node also knows that (its val, what row, what col)
            grid[3, 1] = new Node(2, 3, 1);
            grid[1, 3] = new Node(1, 1, 3);
            grid[0, 2] = new Node(3, 0, 2);
            grid[1, 2] = new Node(3, 1, 2);
            grid[2, 2] = new Node(3, 2, 2);
            grid[3, 2] = new Node(3, 3, 2);
            grid[4, 2] = new Node(3, 4, 2);

            int[] result = FindTarget(grid, 3, 1);
            Console.WriteLine(result[0] + ", " + result[1]);
            Console.WriteLine(CanReachTarget(grid, 3, 1));
        }


//method to reach to the target (from 2 on array to 1 on array. everything else be 0 if can go through them)
        static int[] FindTarget(Node[,] grid, int startRow, int startCol)
        {
            List<Node> queue = new List<Node>();
            HashSet<Node> visited = new HashSet<Node>();
            Node currNode;
            queue.Add(grid[startRow, startCol]);

            while(queue.Count > 0)
            {
                currNode = queue[0];
                queue.Remove(currNode);
                visited.Add(currNode);

                if(currNode.val == 1)
                {
                    return new int[] { currNode.row, currNode.col };
                }

                int row = currNode.row;
                int col = currNode.col;

                if (row - 1 > 0 && !visited.Contains(grid[row - 1, col]))
                {
                    queue.Add(grid[row - 1, col]);
                }
                if (row + 1 < grid.GetLength(0) && !visited.Contains(grid[row + 1, col])){
                    queue.Add(grid[row + 1, col]);
                }
                if (col - 1 > 0 && !visited.Contains(grid[row, col - 1])){
                    queue.Add(grid[row, col - 1]);
                }
                if (col + 1 < grid.GetLength(1) && !visited.Contains(grid[row, col + 1])){
                    queue.Add(grid[row, col + 1]);
                }
            }

            return new int[] { -1, -1 };
        }


//method to check if can reach the target
        static bool CanReachTarget(Node[,] grid, int startRow, int startCol)
        {
            List<Node> queue = new List<Node>(); //the list to store the nodes going through
            HashSet<Node> visited = new HashSet<Node>(); //hash set to store nodes already been on so it doesn't go on them again
            Node currNode; //make node currNode to check
            queue.Add(grid[startRow, startCol]); //to queue add the node on

            while (queue.Count > 0) //while queue not empty
            {
                currNode = queue[0]; //the node on is always chekcing the 1st one (because BFS)
                queue.Remove(currNode); //remove the 1st node so can move off to be able to check next
                visited.Add(currNode); //add to the visited so it doesn't go on it again if already went it is saved (later there is a check if it had been visited before)

                if (currNode.val == 1) //if current node is equal to 1 means reached the target so can reach
                {
                    return true;
                }

                int row = currNode.row; //set
                int col = currNode.col;


//checking the values next to it as it expands to check around. makes sure to verify for 3 to see if possible to use that route cont'
                if (row - 1 > 0 && !visited.Contains(grid[row - 1, col]) && grid[row - 1, col].val != 3)
                {
                    queue.Add(grid[row - 1, col]);
                }
                if (row + 1 < grid.GetLength(0) && !visited.Contains(grid[row + 1, col]) && grid[row + 1, col].val != 3)
                {
                    queue.Add(grid[row + 1, col]);
                }
                if (col - 1 > 0 && !visited.Contains(grid[row, col - 1]) && grid[row, col - 1].val != 3)
                {
                    queue.Add(grid[row, col - 1]);
                }
                if (col + 1 < grid.GetLength(1) && !visited.Contains(grid[row, col + 1]) && grid[row, col + 1].val != 3)
                {
                    queue.Add(grid[row, col + 1]);
                }
            }

            return false; //false returned is not found a way through
        }
    }
}
