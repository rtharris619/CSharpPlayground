using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session43
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var numbers = new List<int> { 0, 1, 2, 5, 7, 8, 9, 9, 10, 11, 15 };
            var result = MergeList(numbers);
            WriteLine(string.Join(", ", result));
        }

        private List<string> MergeList(List<int> numbers)
        {
            var ranges = new List<string>();
            int low = numbers[0];
            int high = numbers[0];

            foreach (int number in numbers)
            {
                if (high + 1 < number)
                {
                    ranges.Add(MakeRange(low, high));
                    low = number;
                }
                high = number;                
            }
            ranges.Add(MakeRange(low, high));
            return ranges;
        }

        private string MakeRange(int low, int high)
        {
            return low.ToString() + "-" + high.ToString();
        }
    }
}
