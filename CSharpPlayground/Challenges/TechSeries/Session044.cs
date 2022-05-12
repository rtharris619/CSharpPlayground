using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session44
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var numbers = new List<int> { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            WriteLine(MaxSubArray(numbers));
        }

        private int MaxSubArray(List<int> numbers)
        {
            var maxSum = 0;
            var sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
                if (sum < 0) sum = 0;
                else maxSum = Math.Max(maxSum, sum);
            }

            return maxSum;
        }
    }
}
