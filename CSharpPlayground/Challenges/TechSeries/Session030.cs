using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session30
{
    // O (2^n) time and space complexity
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var result = GenerateParentheses(3);
            WriteLine(string.Join(",", result));
        }

        private List<string> GenerateParentheses(int n)
        {
            return GenerateParenthesesHelper(n, 0, 0, "");
        }

        private List<string> GenerateParenthesesHelper(int n, int left, int right, string str)
        {
            if (left + right == 2 * n)
            {
                return new List<string> { str };
            }

            var result = new List<string>();

            if (left < n)
            {
                result.AddRange(GenerateParenthesesHelper(n, left + 1, right, str + "("));
            }

            if (right < left)
            {
                result.AddRange(GenerateParenthesesHelper(n, left, right + 1, str + ")"));
            }

            return result;
        }
    }
}
