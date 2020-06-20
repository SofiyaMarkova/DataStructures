/*
given a target value want to see if can get it by adding 2 numbers from an array of numbers.

solution:
use a dictionary to save the number seen as key and save its reciprocal as value
when call up to check if the value needed exists using var2 = value - var1 can check if its reciprocal also exists

if value got and reciprocal exists then both in the array and can make required value

 */
using Sid;
using System;

namespace Sid
{ 
    static int[] twoSum(int[] num, int target)   //passing num on and target value want to make with 2 vals searching for
    {
        Dictionary<int, int> numbers = new Dictionary<int, int>(); //make dictionary data type
        for (i = 0; i < num.length; i++)
        {
            int var1 = numbers[i];

            if (nums.ContainsKey(var1) == true) {
                Console.WriteLine(var1);
                Console.WriteLine(nums[var1]);
            }

            int var2 = Value - var1;
            numbers.Add(var2, i);

        }
        return null;
    }

}





