using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session48
{
    public class Session
    {
        public void Driver()
        {
            Example2();
        }

        private void Example1()
        {
            WriteLine(Staircase(5));
        }

        private void Example2()
        {
            WriteLine(Staircase2(5));
        }

        private int Staircase(int n)
        {
            if (n <= 1) return 1;

            return Staircase(n - 1) + Staircase(n - 2);
        }

        private int Staircase2(int n)
        {
            int prev = 1;
            int prevprev = 1;
            int current = 0;

            for (int i = 2; i <= n; i++)
            {
                current = prev + prevprev; // 2, 3
                prevprev = prev; // 1, 2
                prev = current; // 2, 5
            }

            return current;
        }
    }
}
