using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sid
{
    class Node
    {

        public int val;
        public Node left;
        public Node right;

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
            Node tree = new Node(3);
            tree.left = new Node(4);
            tree.right = new Node(5);
            tree.left.left = new Node(1);
            tree.left.right = new Node(2);
            tree.right.left = new Node(7);
            tree.right.right = new Node(6);

            Console.WriteLine(GetMax(tree));

        }

        public static int GetMax(Node head)
        {
            int maxVal = 0;
            List<Node> queue = new List<Node>();
            queue.Add(head);

            while (queue.Count > 0)
            {
                Node currNode = queue[queue.Count - 1]; // Currently depth first, Swap to 0 for breadth first
                queue.Remove(currNode);

                if(currNode.val > maxVal)
                {
                    maxVal = currNode.val;
                }

                if(currNode.right != null)
                {
                    queue.Add(currNode.right);
                }
                if(currNode.left != null)
                {
                    queue.Add(currNode.left);
                }
            }

            return maxVal;
        }

    }
}
