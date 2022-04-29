using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session38
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
            node.Left.Left = new Node<int>(4);
            node.Right = new Node<int>(3);
            IsBalanced(node);
        }

        private void Example2()
        {
            var node = new Node<int>(1);
            node.Left = new Node<int>(2);
            node.Left.Left = new Node<int>(4);
            IsBalanced(node);
        }

        private void IsBalanced(Node<int> node)
        {
            var isBalanced = IsBalancedHelper(node);
            WriteLine(isBalanced.Item1);
        }

        private Tuple<bool, int> IsBalancedHelper(Node<int> node)
        {
            if (node == null) return new Tuple<bool, int> ( true, 0 );

            var leftResult = IsBalancedHelper(node.Left);
            var rightResult = IsBalancedHelper(node.Right);

            return new Tuple<bool, int>(leftResult.Item1 && rightResult.Item1 && Math.Abs(leftResult.Item2 - rightResult.Item2) <= 1, 
                Math.Max(leftResult.Item2, rightResult.Item2) + 1);
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
