using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session61
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            WriteLine(Fibonacci(9));
        }

        private int Fibonacci(int n)
        {
            int result = 0;
            int a = 0;
            int b = 1;
            if (n == 0) return a;
            if (n == 1) return b;

            for (int i = 2; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }
            return result;
        }
    }
}
