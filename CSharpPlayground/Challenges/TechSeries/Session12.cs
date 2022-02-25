using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session12
{
    public class Session12
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var maxStack = new MaxStack();
            maxStack.Push(1);
            maxStack.Push(2);
            maxStack.Push(3);
            maxStack.Push(2);
            WriteLine(string.Join(",", maxStack.Stack));    
            maxStack.Pop();
            WriteLine(maxStack.Max());
        }
    }

    public class MaxStack
    {
        public List<int> Stack;
        public List<int> Maxes;

        public MaxStack()
        {
            Stack = new List<int>();
            Maxes = new List<int>();
        }

        public void Push(int value)
        {
            Stack.Add(value);
            if (Maxes.Any() && Maxes[Maxes.Count - 1] > value)
            {
                Maxes.Add(Maxes[Maxes.Count - 1]);
            }
            else
            {
                Maxes.Add(value);
            }
        }

        public void Pop()
        {
            Maxes.RemoveAt(Maxes.Count - 1);
            Stack.RemoveAt(Stack.Count - 1);
        }

        public int Max()
        {
            return Maxes[Maxes.Count - 1];
        }
    }
}
