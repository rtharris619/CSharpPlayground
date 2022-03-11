using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session8
{
    // Sorting a list with 3 unique numbers
    // This can be done by sorting the array in place
    // O(n) time and space (linear)

    public class Session8
    {
        public void Driver()
        {
            Example2();
        }

        private void Example1()
        {
            var numbers = new List<int> { 3, 3, 2, 1, 3, 2, 1 };
            var result = SortNumbers(numbers);
            WriteLine(string.Join(",", result));
        }

        private void Example2()
        {
            var numbers = new List<int> { 3, 3, 2, 1, 3, 2, 1 };
            var result = SortNumbersAdvanced(numbers);
            WriteLine(string.Join(",", result));
        }

        private List<int> SortNumbers(List<int> numbers)
        {
            // { [3, 3], [2, 2], [1, 2] }

            var counts = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (counts.ContainsKey(numbers[i]))
                {
                    counts[numbers[i]]++;
                }
                else
                {
                    counts.Add(numbers[i], 1);
                }
            }

            var result = new List<int>();
            result.AddRange(Enumerable.Repeat(1, counts[1]));
            result.AddRange(Enumerable.Repeat(2, counts[2]));
            result.AddRange(Enumerable.Repeat(3, counts[3]));

            return result;
        }

        // Sorts array in place
        private List<int> SortNumbersAdvanced(List<int> numbers)
        {
            var one_index = 0;
            var three_index = numbers.Count - 1;
            var current_index = 0;

            while (current_index <= three_index)
            {
                if (numbers[current_index] == 1)
                {
                    (numbers[current_index], numbers[one_index]) = (numbers[one_index], numbers[current_index]);
                    one_index++;
                    current_index++;
                }
                if (numbers[current_index] == 2)
                {
                    current_index++;
                }
                if (numbers[current_index] == 3)
                {
                    (numbers[current_index], numbers[three_index]) = (numbers[three_index], numbers[current_index]);
                    three_index--;
                }
            }

            return numbers;
        }
    }
}
