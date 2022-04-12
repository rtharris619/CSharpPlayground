using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Trees
{
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

    public class BinaryTree<T>
    {
        public List<T> DFSValues(Node<T> root)
        {
            var result = new List<T>();
            var stack = new Stack<Node<T>>();
            stack.Push(root);

            while (stack.Any())
            {
                var current = stack.Pop();
                result.Add(current.Value);

                if (current.Right != null)
                    stack.Push(current.Right);
                
                if (current.Left != null)
                    stack.Push(current.Left);
            }
            return result;
        }

        public List<T> DFSValuesRec(Node<T> root)
        {
            if (root == null)
                return new List<T>();
            var rightValues = DFSValuesRec(root.Right);
            var leftValues = DFSValuesRec(root.Left);

            var result = new List<T>();
            result.Add(root.Value);
            result.AddRange(leftValues);
            result.AddRange(rightValues);

            return result;
        }

        public List<T> BFSValues(Node<T> root)
        {
            var result = new List<T>();
            var queue = new Queue<Node<T>>();

            queue.Enqueue(root);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                result.Add(current.Value);
                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);                
            }

            return result;
        }

        public bool BFSIncludes(Node<T> root, T target)
        {
            if (root == null) return false;

            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (EqualityComparer<T>.Default.Equals(current.Value, target)) return true;

                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }

            return false;
        }

        public bool DFSIncludes(Node<T> root, T target)
        {
            if (root == null) return false;

            var stack = new Stack<Node<T>>();
            stack.Push(root);

            while (stack.Any())
            {
                var current = stack.Pop();
                if (EqualityComparer<T>.Default.Equals(current.Value, target)) return true;

                if (current.Left != null) stack.Push(current.Left);
                if (current.Right != null) stack.Push(current.Right);
            }

            return false;
        }

        public bool DFSIncludesRecursive(Node<T> current, T target)
        {
            if (current == null) return false;

            if (EqualityComparer<T>.Default.Equals(current.Value, target)) return true;

            return DFSIncludesRecursive(current.Left, target) || DFSIncludesRecursive(current.Right, target);
        }

        public void WriteToConsole(List<T> values)
        {
            foreach (var val in values)
            {
                Console.Write(val + " ");
            }
        }
    }

    public class TestBinaryTree
    {
        public void Driver()
        {
            TestDFSIncludes();
        }

        private void TestDFSValues()
        {
            var tree = new BinaryTree<char>();
            var root = ConstructBinaryTree();
            
            var result = tree.DFSValues(root);

            tree.WriteToConsole(result);
        }

        private void TestBFSValues()
        {
            var tree = new BinaryTree<char>();
            var root = ConstructBinaryTree();

            var result = tree.BFSValues(root);

            tree.WriteToConsole(result);
        }

        private void TestBFSIncludes()
        {
            var tree = new BinaryTree<char>();
            var root = ConstructBinaryTree();

            var result = tree.BFSIncludes(root, 'e');
            Console.WriteLine(result);
        }

        private void TestDFSIncludes()
        {
            var tree = new BinaryTree<char>();
            var root = ConstructBinaryTree();

            var result = tree.DFSIncludesRecursive(root, 'j');
            Console.WriteLine(result);
        }

        private Node<char> ConstructBinaryTree()
        {
            /*
                        a
                    b       c
                d       e       f

            */
            var a = new Node<char>('a');
            var b = new Node<char>('b');
            var c = new Node<char>('c');
            var d = new Node<char>('d');
            var e = new Node<char>('e');
            var f = new Node<char>('f');
            a.Left = b;
            a.Right = c;
            b.Left = d;
            b.Right = e;
            c.Right = f;

            return a;
        }
    }
}
