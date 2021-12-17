using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Stacks
{
    public class Stack
    {
        public List<int> Elements { get; set; }
        public Stack()
        {
            Elements = new List<int>();
        }

        public int? Peek()
        {
            return Elements.Any() ? Elements[Elements.Count - 1] : null;
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
                Elements.RemoveAt(GetLastIndex());
            }
            return itemToRemove;
        }

        private int GetLastIndex()
        {
            return Elements.Any() ? Elements.Count - 1 : 0;
        }
    }

    public class TestStack
    {
        public void Driver()
        {
            var stack = new Stack();
            stack.Put(10);
            stack.Put(20);
            stack.Put(30);
            Console.WriteLine(stack.Pop());
        }
    }
}
