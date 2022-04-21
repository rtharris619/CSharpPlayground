using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session37
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var node = new Node<int>(1);
            node.Left = new Node<int>(2);
            node.Right = new Node<int>(3);
            node.Right.Right = new Node<int>(7);
            node.Left.Left = new Node<int>(4);
            node.Left.Right = new Node<int>(5);

            var values = ValuesAtLevel(node, 3);
            WriteLine(string.Join(",", values));
        }

        private List<int> ValuesAtLevel(Node<int> node, int depth)
        {
            if (node == null) return new List<int>();

            if (depth == 1) return new List<int> { node.Value };

            return ValuesAtLevel(node.Left, depth - 1).Concat(ValuesAtLevel(node.Right, depth - 1)).ToList();
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }
        public Node(T value, Node<T> left = null, Node<T> right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
