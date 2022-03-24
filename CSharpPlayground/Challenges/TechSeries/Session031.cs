using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session31
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var root = new Node<char>('a');
            root.Left = new Node<char>('b');
            root.Left.Left = new Node<char>('d');
            root.Left.Left.Right = new Node<char>('e');
            root.Right = new Node<char> ('c');
            WriteLine(TreeDepth(root));
        }

        private int TreeDepth(Node<char> node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(TreeDepth(node.Left), TreeDepth(node.Right));
        }
    }

    public class Node<T>
    {
        public Node<T>? Left { get; set; } = null;
        public Node<T>? Right { get; set; } = null;
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
