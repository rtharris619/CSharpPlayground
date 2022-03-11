using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session17
{
    // O(2n) time as apposed to O(n^2) time with brute force nested for loop
    public class Session17
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var numbers = new List<int> { 1, 2, 3, 4 };
            WriteLine(string.Join(",", ProductExceptSelf(numbers)));;
        }

        private List<int> ProductExceptSelf(List<int> numbers)
        {
            var result = Enumerable.Repeat(1, numbers.Count).ToList();
            var product = 1;
            for (int i = numbers.Count - 2; i >= 0; i--)
            {
                product *= numbers[i + 1];
                result[i] = product;
            }

            product = 1;
            for (int i = 1; i < numbers.Count; i++)
            {
                product *= numbers[i - 1];
                result[i] *= product;
            }

            return result;
        }
    }
}
