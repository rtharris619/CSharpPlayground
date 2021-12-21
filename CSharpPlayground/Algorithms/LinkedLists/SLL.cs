using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.LinkedLists
{

    public class Node
    {
        public char Value { get; set; }
        public Node? Next { get; set; }

        public Node(char val)
        {
            Value = val;
            Next = null;
        }
    }

    public class SLL
    {
        public void PrintSLL(Node? head)
        {
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public void PrintSLLRec(Node? head)
        {
            if (head == null)
                return;
            Console.WriteLine(head.Value);
            PrintSLLRec(head.Next);
        }

        public List<char> SLLValues(Node? head)
        {
            var values = new List<char>();
            var current = head;
            while (current != null)
            {
                values.Add(current.Value);
                current = current.Next;
            }
            return values;
        }

        public List<char> SLLValuesRec(Node? head)
        {
            var values = new List<char>();

            FillValues(head, values);
            
            return values;
        }

        private void FillValues(Node? node, List<char> values)
        {
            if (node == null)
                return;
            values.Add(node.Value);
            FillValues(node.Next, values);
        }
    }

    public class NumberNode
    {
        public int Value { get; set; }
        public NumberNode? Next { get; set; }

        public NumberNode(int val)
        {
            Value = val;
            Next = null;
        }
    }

    public class NumberSLL
    {
        public int SumList(NumberNode? head)
        {
            var sum = 0;
            var current = head;
            while (current != null)
            {
                sum += current.Value;
                current = current.Next;
            }
            return sum;
        }
    }

    public class TestSLL
    {
        private void CharSLL()
        {
            var a = new Node('A');
            var b = new Node('B');
            var c = new Node('C');
            var d = new Node('D');

            a.Next = b;
            b.Next = c;
            c.Next = d;

            var sll = new SLL();
            //sll.PrintSLLRec(a);

            var values = sll.SLLValuesRec(a);
            values.ForEach(Console.WriteLine);
        }

        private void NumberSLL()
        {
            var a = new NumberNode(2);
            var b = new NumberNode(8);
            var c = new NumberNode(3);
            var d = new NumberNode(7);

            a.Next = b;
            b.Next = c;
            c.Next = d;

            var sll = new NumberSLL();
            Console.WriteLine(sll.SumList(a));
        }

        public void Driver()
        {
            NumberSLL();
        }
    }
}
