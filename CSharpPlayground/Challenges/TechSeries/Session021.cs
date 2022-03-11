using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session21
{
    public class Session21
    {
        // O(n) linear time
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var head = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5, null)))));
            RemoveKthElement(head, 4);
            WriteLine(head.ToString());
        }

        private void RemoveKthElement(Node node, int k)
        {
            var slow = node;
            var fast = node;

            foreach (var i in Enumerable.Range(0, k))
            {
                fast = fast.Next;
            }

            Node? prev = null;
            while (fast != null)
            {
                prev = slow;
                fast = fast.Next;
                slow = slow.Next;
            }
            prev.Next = slow.Next;
        }
    }

    public class Node
    {
        public int Value;
        public Node Next;

        public Node(int value, Node? next)
        {
            Value = value;
            Next = next;
        }

        public override string ToString()
        {
            var node = this;
            var answer = "";
            while (node != null)
            {
                answer += node.Value.ToString();
                node = node.Next;
            }
            return answer;
        }
    }
}
