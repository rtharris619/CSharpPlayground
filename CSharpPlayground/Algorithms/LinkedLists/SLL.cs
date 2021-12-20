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
    }

    public class TestSLL
    {
        public void Driver()
        {
            var a = new Node('A');
            var b = new Node('B');
            var c = new Node('C');
            var d = new Node('D');

            a.Next = b;
            b.Next = c;
            c.Next = d;

            var sll = new SLL();
            sll.PrintSLLRec(a);
        }
    }
}
