using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session7
{
    // Permutations - uses Backtracking
    // O(n!) n * (n - 1) * (n - 2)...* 1

    public class Session7
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var result = Permute(numbers);
            WriteLine(result.Count);
        }

        private void Example2()
        {
            var numbers = Enumerable.Range(1, 10).ToList();
            var result = Permute(numbers);
            WriteLine(result.Count);
        }

        private List<List<int>> Permute(List<int> numbers)
        {
            return PermuteHelper(numbers);
        }

        private List<List<int>> PermuteHelper(List<int> numbers, int start = 0)
        {
            if (start == numbers.Count)
                return new List<List<int>> { numbers };

            var result = new List<List<int>>();

            for (int i = start; i < numbers.Count; i++)
            {
                (numbers[start], numbers[i]) = (numbers[i], numbers[start]);
                result.AddRange(PermuteHelper(numbers, start + 1));
                (numbers[start], numbers[i]) = (numbers[i], numbers[start]);
            }

            return result;
        }

        // Broken still
        private List<List<int>> Permute2(List<int> numbers, List<int>? values = null)
        {
            if (values == null)
                values = new List<int>();

            if (numbers.Count == 0)
                return new List<List<int>> { values };

            var result = new List<List<int>>();

            for (int i = 0; i < numbers.Count; i++)
            {
                values.Add(numbers[i]);

                var first = numbers.GetRange(0, i);
                var rest = numbers.GetRange(i, numbers.Count);

                numbers = first.Concat(rest).ToList();                

                result.AddRange(Permute2(numbers, values));
            }

            return result;
        }
    }
}
