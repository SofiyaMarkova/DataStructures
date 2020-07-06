/*doubly linked lists

what changes from a regular linked list is that the
data type Node now stores also that it remembers the previous Node

a node can store different info. like here it stores size as well.
so technically can get a count for the length of nodes if each nodes stores the number
*/


using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sid
{
    class Node
    {
        int val;
        int size;
        Node next;
        Node prev;

        public Node(Node prev, int val)
        {
            this.val = val;
            next = null;
            this.prev = prev;
            size = 1;
        }

        public void AddNode(Node newNode)
        {
            Node currNode = this;
            while(currNode.next != null)
            {
                currNode = currNode.next;
            }
            currNode.next = newNode;
            newNode.prev = currNode;
            size++;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Node head = new Node(null, 3);
            Node newNode = new Node(head, 5);
            Node newNode2 = new Node(head, 7);
            head.AddNode(newNode);
            head.AddNode(newNode2);
        }


    }
}
