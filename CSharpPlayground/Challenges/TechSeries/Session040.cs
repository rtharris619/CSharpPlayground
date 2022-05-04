using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session40
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
            node.Left.Left = new Node<int>(4);

            //WriteLine(MaxDepthRecursive(node));
            WriteLine(MaxDepth(node));
        }

        private int MaxDepthRecursive(Node<int> node)
        {
            return MaxDepthRecursiveHelper(node);
        }

        private int MaxDepthRecursiveHelper(Node<int> node)
        {
            if (node == null) return 0;

            return 1 + Math.Max(MaxDepthRecursiveHelper(node.Left), MaxDepthRecursiveHelper(node.Right));
        }

        private int MaxDepth(Node<int> node)
        {
            var stack = new Stack<Tuple<int, Node<int>>>();
            stack.Push(new Tuple<int, Node<int>>(1, node));

            int maxDepth = 1;

            while (stack.Any())
            {
                var current = stack.Pop();
                maxDepth = current.Item1;
                
                if (current.Item2.Left != null) stack.Push(new Tuple<int, Node<int>>(current.Item1 + 1, current.Item2.Left));
                if (current.Item2.Right != null) stack.Push(new Tuple<int, Node<int>>(current.Item1 + 1, current.Item2.Right));
            }
            return maxDepth;
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
