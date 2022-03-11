using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session22
{
    public class Session22
    {
        public void Driver()
        {
            Example1();
            Example2();
        }

        private void Example1()
        {
            var stringToTest = "(){([])}";
            WriteLine(IsValid(stringToTest));
        }

        private void Example2()
        {
            var stringToTest = "(){([";
            WriteLine(IsValid(stringToTest));
        }

        private bool IsValid(string stringToTest)
        {
            var stack = new Stack<char>();

            var parenthesisMap = new Dictionary<char, char>
            {
                { '[', ']' }, 
                { '{', '}' }, 
                { '(', ')' }
            };

            foreach (char c in stringToTest)
            {
                if (parenthesisMap.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (parenthesisMap.ContainsValue(c))
                {
                    if (stack.Count == 0 || !parenthesisMap.ContainsKey(stack.Peek()))
                    {
                        return false;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
