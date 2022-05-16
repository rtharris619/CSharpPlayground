using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session46
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var node = new Node("a");
            node.Left = new Node("b");
            node.Right = new Node("c");
            node.Left.Left = new Node("d");
            node.Left.Right = new Node("e");
            node.Right.Left = new Node("f");
            
            WriteLine(node.ToString());
            Invert(node);
            WriteLine(node.ToString());

        }

        private Node Invert(Node node)
        {
            if (node == null) return null;

            var left = Invert(node.Left);
            var right = Invert(node.Right);

            node.Right = left;
            node.Left = right;

            return node;
        }
    }

    public class Node
    {
        public string Value { get; set; }
        public Node Left { get; set; } = null;
        public Node Right { get; set; } = null;

        public Node(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            var result = Value;
            result += Left != null ? Left.ToString() : "";
            result += Right != null ? Right.ToString() : "";
            return result;
        }
    }
}
