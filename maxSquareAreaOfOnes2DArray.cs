/*have 2D array of numbers filled with 0 or 1
want to find the largest area of a square can make with the 1s
so if have a square of 1s side by side that is 2x2, greatest area is 4.
each individual 1 is just the area 1 (own small square)

was solved with the concept of dynamic programming because the question each spot is asked it:
what is the largest square side length that can be if I am the right bottom of the square
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
            int[][] nums = new int[5][];

            for (int row = 0; row < nums.Length; row++)
            {
                nums[row] = new int[5];
            }

            nums[0][0] = 1;
            nums[0][1] = 0;
            nums[0][2] = 1;
            nums[0][3] = 1;
            nums[0][4] = 0;
            nums[1][0] = 1;
            nums[1][1] = 1;
            nums[1][2] = 1;
            nums[1][3] = 1;
            nums[1][4] = 1;
            nums[2][0] = 1;
            nums[2][1] = 1;
            nums[2][2] = 1;
            nums[2][3] = 1;
            nums[2][4] = 1;
            nums[3][4] = 1;
            nums[3][4] = 0;
            nums[3][4] = 1;
            nums[3][4] = 1;
            nums[3][4] = 1;

            Console.WriteLine(MaximalSquare(nums));

        }

        static int MaximalSquare(int[][] nums)
        {

            int greatestSideLength = 0;
            int currentSideLength = 0;

            //start at [1][1] (no point checking others before that). so row = 1 and col = 1
            for (int row = 1; row < nums.Length; row++)
            {
                for (int col = 1; col < nums[row].Length; col++)
                {

                    //no point check if row or col == 0 because can't make square anyways
                    if (row == 0 || col == 0)
                    {
                        continue;
                    }

                    //if a 0, can't be a square anyways
                    if (nums[row][col] == 0)
                    {
                        continue;
                    }


                    //for the case that it makes a larger square there => the will be all equal
                    if (((nums[row - 1][col - 1] == nums[row - 1][col]) && (nums[row - 1][col] ) == nums[row][col - 1]) && nums[row - 1][col - 1] > 0 && nums[row - 1][col] > 0 && nums[row][col - 1] > 0)
                    {
                        nums[row][col] = nums[row][col - 1] + 1;  //take any of those that equal to each other and +1 to that value, to put into current square

                    }

                    //for the case just there are non-zeros around the current square but not all the same, so no bigger square as a whole, but may be part of smaller square
                    if (nums[row - 1][col - 1] > 0 && nums[row - 1][col] > 0 && nums[row][col - 1] > 0)
                    {

                        //get the minimum so can +1 to that to put into current square


                        if (nums[row - 1][col - 1] <= nums[row - 1][col] && nums[row - 1][col - 1] <= nums[row][col - 1])
                        {
                            nums[row][col] = nums[row - 1][col - 1] + 1;
                        }
                        if (nums[row - 1][col] <= nums[row - 1][col - 1] && nums[row - 1][col] <= nums[row][col - 1])
                        {
                            nums[row][col] = nums[row - 1][col] + 1;
                        }
                        if (nums[row][col - 1] <= nums[row - 1][col - 1] && nums[row][col - 1] <= nums[row - 1][col])
                        {
                            nums[row][col] = nums[row][col - 1] + 1;
                        }

                    }


                    //get the value created on that square
                    currentSideLength = nums[row][col];

                    //compare it to greatestArea had so far, so can make the new area the greatest if it is greater
                    if (currentSideLength > greatestSideLengtha)
                    {
                        greatestSideLength = currentSideLength;

                    }


                }


            }

            return greatestSideLength * greatestSideLength; //greatestArea is the 2 sides multiplied together because square = length*length
        }
    }
}
