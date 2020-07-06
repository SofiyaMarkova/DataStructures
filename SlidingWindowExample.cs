/*
looks through string to find the longest unique string which is
a string without repeating uniqueLetters
was solved with the "sliding window" method
space complexity: O(n) because needs to go through all letters in a string x1
implementing the use of a HashSet O(1) made it more efficient than trying to store in some different list type
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
          //to print into console the answer to when run the program with the input given here as a string
            Console.WriteLine(GetLargestUniqueString("penwwkuier"));
        }

//gets string input
        static int GetLargestUniqueString(string input)
        {
          //create a hashset to store letters so can check against if seen them before
          //hashset is O(1) unlike traversing a string is O(n) because just need to ask if element is in set
            HashSet<char> uniqueLetters = new HashSet<char>();
            int max_size = 0;
            int left = 0;
            int right = 0;

//go while right not reach the end of string (that means all was checked)
            while(right < input.Length)
            {

              //if the letter on right now is in the uniqueLetters set (so there is a repeat).
                if (uniqueLetters.Contains(input[right]))
                {
//remove from the left (slide left window 1 to the right to make up for the fact that there was repeating)
//the loop makes sure that if there are 3 same letters in a row: it will keep doing left++ until start at where right was
//so starts from the beginning where no repeating letters. (if not have this it will miss the case with 3 repeating letters)
while(input[left] != input[right])
{
    uniqueLetters.Remove(input[left]);
    left++;
}
                }
                else //if not a repeat
                {
                  //add the seen letter to the uniqueLetters so then can compare against it later
                    uniqueLetters.Add(input[right]);
                    if(uniqueLetters.Count > max_size) //checking is the count of uniqueLetters seen is larger than the count for uniqueLetters so far
                    {
                        max_size = uniqueLetters.Count; //sets the max_size to be the larger size found
                    }
                }
//move right 1 to the right to continue checking
                right += 1;
            }

            return max_size; //once done all return max_size that was possible for a unique word that was made
        }
    }
}
