using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session56
{
    public class Session
    {
        public void Driver()
        {
            Example2();
        }

        //    1
        //   / \
        //  2   3  
        //     / \
        //    4*  5
        
        private void Example1()
        {
            var a = new Node<int>(1);
            a.Left = new Node<int>(2);
            a.Right = new Node<int>(3);
            a.Right.Left = new Node<int>(4);
            a.Right.Right = new Node<int>(5);

            var b = new Node<int>(1);
            b.Left = new Node<int>(2);
            b.Right = new Node<int>(3);
            b.Right.Left = new Node<int>(4);
            b.Right.Right = new Node<int>(5);

            WriteLine(FindNode(a, b, a.Right.Left));
        }

        private void Example2()
        {
            var a = new Node<int>(1);
            a.Left = new Node<int>(2);
            a.Right = new Node<int>(3);
            a.Right.Left = new Node<int>(4);
            a.Right.Right = new Node<int>(5);

            var b = new Node<int>(1);
            b.Left = new Node<int>(2);
            b.Right = new Node<int>(3);
            b.Right.Left = new Node<int>(4);
            b.Right.Right = new Node<int>(5);

            WriteLine(FindNodeIterative(a, b, a.Right.Left));
        }

        private Node<int> FindNode(Node<int> a, Node<int> b, Node<int> node)
        {
            if (a == node) return b;

            if (a.Left != null && b.Left != null)
            {
                var found = FindNode(a.Left, b.Left, node);
                if (found != null) return found;
            }

            if (a.Right != null && b.Right != null)
            {
                var found = FindNode(a.Right, b.Right, node);
                if (found != null) return found;
            }

            return null;
        }

        private Node<int> FindNodeIterative(Node<int> a, Node<int> b, Node<int> node)
        {
            var stack = new Stack<NodeComparator>();
            stack.Push(new NodeComparator { NodeA = a, NodeB = b });

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                a = current.NodeA;
                b = current.NodeB;
                if (a == node) return b;

                if (a.Left != null && b.Left != null)
                {
                    stack.Push(new NodeComparator { NodeA = a.Left, NodeB = b.Left });
                }

                if (a.Right != null && b.Right != null)
                {
                    stack.Push(new NodeComparator { NodeA = a.Right, NodeB = b.Right });
                }
            }

            return null;
        }

        public class NodeComparator
        {
            public Node<int> NodeA { get; set; }
            public Node<int> NodeB { get; set; }
        }

    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; } = null;
        public Node<T> Right { get; set; } = null;

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
