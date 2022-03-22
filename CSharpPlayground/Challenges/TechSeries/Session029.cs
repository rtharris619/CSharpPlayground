using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session29
{
    public class Session29
    {
        public void Driver()
        {
            Example2();
        }

        private void Example1()
        {
            var a = new Node(1, new Node(3, new Node(5)));
            var b = new Node(2, new Node(4, new Node(6)));
            var lists = new List<Node> {a, b };
            var result = Merge(lists);
            WriteLine(result);
        }

        private void Example2()
        {
            var a = new Node(1, new Node(3, new Node(5)));
            var b = new Node(2, new Node(4, new Node(6)));
            var lists = new List<Node> { a, b };
            var result = Merge2(lists);
            WriteLine(result);
        }

        // O(n log n) Time
        private Node Merge(List<Node> lists)
        {
            var array = new List<int>();

            foreach (var node in lists)
            {
                var current = node;
                while (current != null)
                {
                    array.Add(current.Value);
                    current = current.Next;
                }
            }
            array.Sort();

            Node head = null;
            Node root = null;

            for (var i = 0; i < array.Count; i++)
            {                
                if (head == null)
                {
                    head = root = new Node(array[i]);
                }
                else
                {
                    root.Next = new Node(array[i]);
                    root = root.Next;
                }
            }

            return head;
        }

        private Node Merge2(List<Node> lists)
        {
            Node head = null;
            Node current = null;
            head = current = new Node(-1);

            var a = lists[0].Value; // 1
            var b = lists[1].Value; // 2

            foreach (var node in lists)
            {
                while (current != null)
                {
                    current.Next = new Node(node.Value);
                    current = current.Next;
                }
            }

            //for (var i = 0; i < lists.Count; i++)
            //{
            //    var node = lists[i];


            //    lists[i] = lists[i].Next;
            //    current.Next = new Node(node.Value);
            //    current = current.Next;
            //}

            return head.Next;
        }
    }

    public class Node
    {
        public int Value;
        public Node Next;

        public Node(int value, Node? node = null)
        {
            Value = value;
            Next = node;
        }

        public override string ToString()
        {
            var node = this;
            var result = "";
            while (node != null)
            {
                result += node.Value.ToString() + " ";
                node = node.Next;
            }
            return result;
        }
    }
}
