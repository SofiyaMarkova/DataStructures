/*making a tree with nodes that are smaller on left, larger on right as going down the tree*/

using System;
using System.Collections.Generic;

namespace Sid
{
    class Node
    {//declare variables for making node objects
        public int val;
        public Node left;
        public Node right;

//when creating node object: pass int val for it to store. by default it does not have left/right children yet
        public Node(int val)
        {
            this.val = val;
            left = null;
            right = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(8);//make head with value 8
            //AddNode(head, new Node(8));
            AddNode(head, new Node(4)); //AddNode command and pass the head and Node with value in it. the Node will get attached to the head
            AddNode(head, new Node(6));
            Console.WriteLine(IsInTree(head, 5));
        }

//**head is not just the very top. the head becomes any node above as set in recursive form

//method to adding a node
        public static void AddNode(Node head, Node node) //passing as can see in recursive call: the head node above and the node working with trying to add
        {
            if (head.val > node.val) //when head has higher value than current node
            {
                if(head.left == null) //add to left (left is smaller and head is larger than node so smaller => left). if not have left child yet
                {
                    head.left = node; //set left of the head to be the current node
                }
                else
                {
                    AddNode(head.left, node); //or if already has a left, recursively run program again
                }
            }
            else //when head has smaller value than current node (the only other option)
            {
                if(head.right == null) //add to right (right is larger and head is smaller than node so larger => left). if not have right child yet
                {
                    head.right = node; //set right of the head to be the current node
                }
                else
                {
                    AddNode(head.right, node); //or if already has a right, recursively run program again
                }
            }
        }

//method to checking if node value wanted is already in tree. pass in node working on and the n value looking for
        public static bool IsInTree(Node head, int n)
        {
            if(head == null) //if there is no nodes == head is empty, then the value certainly not in tree
            {
                return false;
            }
            else if(head.val == n) //if on the node that currently on is the value => found the value so return true
            {
                return true;
            }
            else if(head.val > n) //if the node on right now is larger than n checking ==> need go to left (because left is smaller values)
            {
                bool foundVal = IsInTree(head.left, n); //call recursively to check further, going left
                return foundVal; //**note must still return the value because above just calls the function to run again and check. the actual answer of process needs to be saved to the boolean and returned
            }
            else //if the node on right now is smaller than n checking ==> need go to right (because right is smaller values) [the only other option]
            {
                bool foundVal = IsInTree(head.right, n); //call recursively to check further, going right
                return foundVal; //the important part that need to return answer of function
            }
        }
    }
}
