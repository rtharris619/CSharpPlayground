using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session11
{
    // O(n) time and space complexity when using Stack
    // O(n) time complexity and O(1) space complexity when using in-place pointer manipulation

    public class Session11
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            // 1 2 3 4 5
            var root = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
            WriteLine(root);

            WriteLine(Reverse(root));
        }

        private Node Reverse(Node node)
        {
            Node current = node;
            Node previous = null;

            while (current != null)
            {
                var temp = current.Next;
                current.Next = previous;
                previous = current;
                current = temp;
            }

            return previous;
        }
    }

    public class Node
    {
        public int Value;
        public Node Next;

        public Node(int val, Node next = null)
        {
            Value = val;
            Next = next;
        }

        public override string ToString()
        {
            var result = Value.ToString();
            if (Next != null)
            {
                result += Next.ToString();
            }
            return result;
        }
    }
}
