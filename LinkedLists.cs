/*linked lists*/
using System;
using System.Collections.Generic;

namespace Sid
{
    class Node
    {
        public int val;
        public Node next;

        public Node(int val)
        {
            this.val = val;
            next = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(8);
            //AddNode(head, new Node(8));
            AddNode(head, new Node(4));
            AddNode(head, new Node(6));
            PrintLinkedList(head);
            Console.WriteLine(IsInTree(head, 5));
            Console.WriteLine(IsInTree(head, 6));
            head = null;
            Console.WriteLine(GetMaxValue(head, new Node(-100000)).val);
        }


//adding node method (on linked lists).
        public static void AddNode(Node head, Node node)
        {
            if(head == null) //if head is null so ther is nothing on it ==> set the node made passed to be the head (one time make head the very first head)
            {
                head = node;
            }
            else
            {
                if(head.next == null) //if there is nothing next to the current node on (counted as head). then make the next node be the node want to see where to put
                {
                    head.next = node;
                }
                else
                {
                    AddNode(head.next, node); //recursively send the next node of head and the node want to put (so comparing the fact that want to link it on)
                }  //note: its like linking on. send the fact that head has a next. and a random node. the node becomes the head's next after the check through
            }
        }

//method to print linked list
        public static void PrintLinkedList(Node head)
        {
            if(head == null) //if node on which is already have no value then return
            {
                return;
            }
            else
            {
                Console.WriteLine(head.val); //print the value of current node
                PrintLinkedList(head.next); //recursively send the node that is next
            }
        }
//**note: a linked list node knows 2 things: the value it holds and who is the node next to it



//method to check if in linked list (not tree. it is linked list so linear there is no split)
        public static bool IsInTree(Node head, int n)
        {
            if (head == null) //if already went through all the nodes and then the node is null means value was not found so it is not in list => false. null node means reached end of linked list
            {
                return false;
            }
            else
            {
                if(head.val == n) //if value looking for is on current head then there you go it is in list so true
                {
                    return true;
                }
                else
                {
                    return IsInTree(head.next, n); //recursively send next node (because current node knows 2 things: what value it has and who is next to it). and passing the value looking for again
                }
            }
        }

//method to get max value in the linxed list
        public static Node GetMaxValue(Node head, Node currMax)
        {
            if(head == null)  //reached null means end of linked list so return what have now all got is end
            {
                return currMax;
            }

            if(head.val > currMax.val) //if current node (looking from its perspective so its the head) value is larger than the max storing
            {
                currMax = head; //set current node to be the max
            }

            return GetMaxValue(head.next, currMax); //recursively send again the next node and the current max saving to compare it to (the actual node is sent. from that node can verify what its value is)
        }
    }
}
