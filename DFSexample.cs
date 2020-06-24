using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sid
{
    

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(CanOpenLock(0, new List<int>(), 2347));
        }

        static bool CanOpenLock(int startPosition, List<int> deadends, int target)
        {
            Queue<int> need_to_check = new Queue<int>();
            HashSet<int> seen = new HashSet<int>();
            HashSet<int> deadEndSet = new HashSet<int>();

            foreach(int n in deadends)
            {
                deadEndSet.Add(n);
            }

            need_to_check.Enqueue(startPosition);
            seen.Add(startPosition);

            while(need_to_check.Count > 0)
            {
                int curr_node = need_to_check.Dequeue();

                if(curr_node == target)
                {
                    return true;
                }

                List<int> possibleStates = GetNextStates(curr_node);

                foreach(int possibleState in possibleStates)
                {
                    if(!deadEndSet.Contains(possibleState) && !seen.Contains(possibleState))
                    {
                        need_to_check.Enqueue(possibleState);
                        seen.Add(possibleState);
                    }
                }
            }
            return false;
        }

        static List<int> GetNextStates(int state)
        {
            // 2358
            List<int> nextStates = new List<int>();

            for(int i = 0; i < 4; i++)
            {
                int val = (int)Math.Pow(10, i);
                int result = (state / val) % 10;

                if(result == 9)
                {
                    nextStates.Add(Math.Abs(state - (9 * val)));
                }
                else
                {
                    nextStates.Add(Math.Abs(state + (val)));
                }

                if(result == 0)
                {
                    nextStates.Add(Math.Abs(state + (9 * val)));
                }
                else
                {
                    nextStates.Add(Math.Abs(state - (val)));
                }
            }

            return nextStates;
            
        }
    }
}
