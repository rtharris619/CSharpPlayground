using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session23
{
    public class Session23
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var numbers = new List<int> { 3, 5, 2, 4, 6, 8 };
            int k = 3;
            WriteLine(FindKthLargestBruteForce(numbers, k));
        }

        private int FindKthLargestBruteForce(List<int> numbers, int k)
        {
            numbers.Sort();
            return numbers[numbers.Count - k];
        }
    }
}
