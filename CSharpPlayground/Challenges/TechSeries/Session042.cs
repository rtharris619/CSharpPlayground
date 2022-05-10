using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session42
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var numbers = new List<int> { 2, 3, 1, 2, 4, 3 };
            var k = 7;

            WriteLine(MinSubArray(k, numbers));
        }

        private int MinSubArray(int k, List<int> numbers)
        {
            var leftIndex = 0;
            var rightIndex = 0;
            var sum = 0;
            var minLength = int.MaxValue;

            while (rightIndex < numbers.Count())
            {
                sum += numbers[rightIndex];
                while (sum >= k)
                {
                    minLength = Math.Min(minLength, rightIndex - leftIndex + 1);
                    sum -= numbers[leftIndex];
                    leftIndex++;
                }
                rightIndex++;
            }

            return minLength;
        }
    }
}
