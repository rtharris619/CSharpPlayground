using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session39
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            /*      0
             *     / \
             *    1   0
             *       / \
             *      1   0
             *     / \
             *    1   1              
             */
            var node = new Node<int>(0);
            node.Left = new Node<int>(1);
            node.Right = new Node<int>(0);
            node.Right.Left = new Node<int>(1);
            node.Right.Right = new Node<int>(0);
            node.Right.Left.Left = new Node<int>(1);
            node.Right.Left.Right = new Node<int>(1);
            WriteLine(CountUnivalSubtrees(node).Item1);
        }

        private Tuple<int, bool> CountUnivalSubtrees(Node<int> node)
        {
            return CountUnivalSubtreesHelper(node);
        }

        private Tuple<int, bool> CountUnivalSubtreesHelper(Node<int> node)
        {
            if (node == null) return new Tuple<int, bool>(0, true);

            var leftNode = CountUnivalSubtreesHelper(node.Left);
            var rightNode = CountUnivalSubtreesHelper(node.Right);

            if (leftNode.Item2 && rightNode.Item2 && 
                (node.Left == null || node.Value == node.Left.Value) &&
                (node.Right == null || node.Value == node.Right.Value))
            {
                return new Tuple<int, bool>(leftNode.Item1 + rightNode.Item1 + 1, true);
            }

            return new Tuple<int, bool>(leftNode.Item1 + rightNode.Item1, false);
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
