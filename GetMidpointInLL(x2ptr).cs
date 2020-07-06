/*
finds the middle of the linked lists. to return the middle if odd amount nodes
and first out of the 2 middle ones if even amount nodes

using a principle of 2 pointers.
how double pointers work here:
1 pointer moves 2 nodes, the other pointer moves 1 node.
by the time that the fast pointer reaches the end, the slow pointer be at the "middle".
so return the value at the slow "pointer" (pointer because becomes saved node into what call "slow" var of node type)

2 pointers are of big use here because it keeps the compelxity to O(n) as it only has to go
once and during the go it checks for the middle
doing 2 pointers at the same time so not have to traverse again after. saves on time complexity

time compelxity: O(n)
*/

﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sid
{
    class Node
    {
        int val;
        Node next;
//create node object
        public Node(int val)
        {
            this.val = val;
            next = null;
        }
//making nodes method (gets called in main to create the linked list as wish)
        public void AddNode(Node newNode)
        {
            Node currNode = this;
            while(currNode.next != null)
            {
                currNode = currNode.next;
            }
            currNode.next = newNode;
        }
//method to get midpoint value
        public int GetMidPointVal()
        {
          //creating 2 pointers. fast moves by 2 nodes, slow moves by 1 node
            Node fast = this;
            Node slow = this;

//while the fast one is not at the end of linked list (the end would be that on that node the next node is null since end of list)
            while(fast.next != null)
            {
              //fast goes 1 over
                fast = fast.next;

                //if fast is not null
                if(fast.next != null)
                {
                  //move another time the fast (because overall fast moves 2 nodes each time)
                    fast = fast.next;
                }
                //if the next is null then break to get out because can't move forward in list
                //breaks here so that out of this loop and slow does not move again.
                //check gets done after fast node reaches the end
                else
                {
                    break; //means whatever slow was on is the middle node because can't move fast any more
                }

                //slow moves over by 1
                slow = slow.next;
            }

//once out of the loop. where the slow "pointer" was on is the middle node. so return the value at that node
            return slow.val;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {//creating nodes
            Node head = new Node(3);
            Node newNode = new Node(5);
            Node newNode2 = new Node(7);
            Node newNode3 = new Node(9);
            Node newNode4 = new Node(11);
          //populating linked list by adding nodes
            head.AddNode(newNode);
            head.AddNode(newNode2);
            head.AddNode(newNode3);
            head.AddNode(newNode4);



        }


    }
}
