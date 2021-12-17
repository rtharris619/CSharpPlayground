using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Queues
{
    public class Queue
    {
        public List<int> Elements { get; set; }
        
        public Queue()
        {
            Elements = new List<int>();
        }

        public int? Peek()
        {
            return Elements.Any() ? Elements[0] : null;
        }

        public void Put(int value)
        {
            Elements.Add(value);
        }

        public int? Pop()
        {
            var itemToRemove = Peek();

            if (itemToRemove != null)
            {
                Elements.RemoveAt(0);
            }
            
            return itemToRemove;
        }
    }

    public class TestQueue
    {
        public void Driver()
        {
            var queue = new Queue();
            queue.Put(10);
            queue.Put(9);
            queue.Put(8);
            Console.WriteLine(queue.Pop());
        }
    }
}
