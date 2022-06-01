using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session55
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            WriteLine(FindKthLargest(new List<int> { 8, 7, 2, 3, 4, 1, 5, 6, 9, 0 }, 3));
        }

        private int FindKthLargest(List<int> numbers, int k)
        {
            numbers.Sort();
            return numbers[numbers.Count - k];
        }
    }
}
