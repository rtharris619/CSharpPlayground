using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session27
{
    public class Session27
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            WriteLine(queue.Dequeue());
            WriteLine(queue.Dequeue());
            WriteLine(queue.Dequeue());
            WriteLine(queue.Dequeue());
        }
    }

    public class Queue
    {
        public Stack<int> Stack1;
        public Stack<int> Stack2;

        public Queue()
        {
            Stack1 = new Stack<int>();
            Stack2 = new Stack<int>();
        }
        
        public void Enqueue(int value)
        {
            Stack1.Push(value);
        }

        public int Dequeue()
        {
            if (Stack2.Count > 0)
            {
                return Stack2.Pop();
            }

            if (Stack1.Count > 0)
            {
                while (Stack1.Count > 0)
                {
                    Stack2.Push(Stack1.Pop());
                }
                return Stack2.Pop();
            }

            return 0;
        }
    }

}
