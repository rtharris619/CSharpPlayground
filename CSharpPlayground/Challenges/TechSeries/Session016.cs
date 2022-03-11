using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session16
{
    // O(n) linear time

    public class Session16
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var result = Evaluate("-(3+(2-1))", 0);
            WriteLine(result);
        }

        private Tuple<int, int> Evaluate(string expression, int index)
        {
            var op = '+';
            var result = 0;

            while (index < expression.Length)
            {
                var character = expression[index];
                if (character == '+' || character == '-')
                {
                    op = character;
                }
                else
                {
                    bool isDigit = int.TryParse(character.ToString(), out int value);
                    if (!isDigit) value = 0;

                    if (character == '(')
                    {
                        (value, index) = Evaluate(expression, index + 1);
                    }
                    if (op == '+')
                    {
                        result += value;
                    }
                    if (op == '-')
                    {
                        result -= value;
                    }
                }
                index++;
            }
            return new Tuple<int, int>(result, index);
        }
    }
}
