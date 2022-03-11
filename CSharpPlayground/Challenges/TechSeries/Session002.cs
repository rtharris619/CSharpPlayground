using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session2
{
    // Checking for a Valid Binary Search Tree 
    // O(n) time and space

    public class Session2
    {
        public void Driver()
        {
            Example1();
        }

        public void Example1()
        {
            //   5
            //  / \
            // 4   7

            var root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(7);
            WriteLine(new Tree().IsValidBST(root));
        }
    }

    public class Node
    {
        public double Value;
        public Node Left;
        public Node Right;

        public Node(double value, Node left = null, Node right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }
    }

    public class Tree
    {
        private bool IsValidBSTHelper(Node node, double low, double high)
        {
            if (node == null) return true;

            var value = node.Value;
            if (value > low && 
                value < high && 
                IsValidBSTHelper(node.Left, low, value) && 
                IsValidBSTHelper(node.Right, value, high))
            {
                return true;
            }
            return false;
        }

        public bool IsValidBST(Node root)
        {
            return IsValidBSTHelper(root, double.NegativeInfinity, double.PositiveInfinity);
        }
    }
}
