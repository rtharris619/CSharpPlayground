using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session28
{
    public class Session28
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var node = new Node(3);
            node.Next = new Node(1);
            node.Next.Next = new Node(2);
            node.Next.Next.Next = new Node(-1);
            node.Next.Next.Next.Next = new Node(-2);
            node.Next.Next.Next.Next.Next = new Node(4);
            node.Next.Next.Next.Next.Next.Next = new Node(1);
            WriteLine(node.ToString());

            RemoveZeroSumSublists(node);
        }

        private Node RemoveZeroSumSublists(Node node)
        {
            var sumToNode = new OrderedDictionary();
            var sum = 0;
            var dummy = new Node(0);
            dummy.Next = node;
            node = dummy;

            while (node != null)
            {
                sum += node.Value;
                if (!sumToNode.Contains(sum))
                {
                    sumToNode.Add(sum, node);
                }
                else
                {
                    var previous = (Node)sumToNode[sum];
                    previous.Next = node.Next;

                    int[] keys = new int[sumToNode.Count];
                    sumToNode.CopyTo(keys, 0);

                    var lastIndex = keys[keys.Length - 1];
                    var lastNode = (Node)sumToNode[lastIndex];

                    while (lastNode.Value != sum)
                    {
                        sumToNode.RemoveAt(lastIndex);
                    }
                }
                node = node.Next;
            }

            return node;
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
