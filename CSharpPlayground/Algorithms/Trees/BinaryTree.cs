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

    public class BinaryTree
    {
        public List<char> DFSValues(Node<char> root)
        {
            var result = new List<char>();
            var stack = new Stack<Node<char>>();
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

        public List<char> DFSValuesRec(Node<char> root)
        {
            if (root == null)
                return new List<char>();
            var rightValues = DFSValuesRec(root.Right);
            var leftValues = DFSValuesRec(root.Left);

            var result = new List<char>();
            result.Add(root.Value);
            result.AddRange(leftValues);
            result.AddRange(rightValues);

            return result;
        }

        public List<char> BFSValues(Node<char> root)
        {
            var result = new List<char>();
            var queue = new Queue<Node<char>>();

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
    }

    public class TestBinaryTree
    {
        public void Driver()
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

            var tree = new BinaryTree();
            var result = tree.DFSValues(a);

            foreach (var val in result)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();

            var bfsResult = tree.BFSValues(a);

            foreach (var val in bfsResult)
            {
                Console.Write(val + " ");
            }
        }
    }
}
