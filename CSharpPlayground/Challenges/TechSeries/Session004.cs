using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Challenges.TechSeries.Session4
{
    // Adding 2 numbers together using a linked list
    // 

    public class Session4
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            // 342 + 465
            var number1 = new Node(2);
            number1.Next = new Node(4);
            number1.Next.Next = new Node(3);

            var number2 = new Node(5);
            number2.Next = new Node(6);
            number2.Next.Next = new Node(4);

            var linkedlist = new LinkedList();
            var result = linkedlist.AddTwoNumbers(number1, number2);
            
            while (result != null)
            {
                Console.Write(result.Value);
                result = result.Next;
            }
        }
    }

    public class Node
    {
        public int Value;
        public Node Next;

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public class LinkedList
    {
        public Node AddTwoNumbers(Node number1, Node number2)
        {
            return AddTwoNumbersIterative(number1, number2);
            //return AddTwoNumbersHelper(number1, number2, 0);
        }

        private Node AddTwoNumbersHelper(Node number1, Node number2, int carryOver)
        {
            Node result;

            var value = number1.Value + number2.Value + carryOver;
            carryOver = value / 10;
            result = new Node(value % 10);

            if (number1.Next != null || number2.Next != null)
            {
                if (number1.Next == null)
                {
                    number1.Next = new Node(0);
                }
                if (number2.Next == null)
                {
                    number2.Next= new Node(0);
                }
                result.Next = AddTwoNumbersHelper(number1.Next, number2.Next, carryOver);
            }

            return result;
        }

        private Node AddTwoNumbersIterative(Node number1, Node number2)
        {
            var Number1 = number1;
            var Number2 = number2;
            var carryOver = 0;

            Node result = null;
            Node current = null;

            while (Number1 != null || Number2 != null)
            {
                var value = Number1.Value + Number2.Value + carryOver;
                carryOver = value / 10;

                if (current == null)
                {
                    result = current = new Node(value % 10);
                }
                else
                {
                    current.Next = new Node(value % 10);
                    current = current.Next;
                }

                if (Number1.Next != null || Number2.Next != null)
                {
                    if (Number1.Next == null)
                    {
                        Number1.Next = new Node(0);
                    }
                    if (Number2.Next == null)
                    {
                        Number2.Next = new Node(0);
                    }
                }

                Number1 = Number1.Next;
                Number2 = Number2.Next;
            }

            return result;
        }
    }
}
