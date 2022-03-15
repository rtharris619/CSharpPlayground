using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpPlayground.Helpers.TwoDimensionalListHelper;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session24
{
    public class Session24
    {
        public void Driver()
        {
            Example3();
        }

        private void Example1()
        {
            var numbers = new List<int> { -1, 0, 1, 2, -4, -3 };
            var result = ThreeSumBruteForce(numbers);
            result.Display();
        }

        private void Example2()
        {
            var numbers = new List<int> { -1, 0, 1, 2, -4, -3 };
            var result = ThreeSumHashMap(numbers);
            result.Display();
        }

        private void Example3()
        {
            var numbers = new List<int> { -1, 0, 1, 2, -4, -3 };
            var result = ThreeSumIndices(numbers);
            result.Display();
        }

        private List<List<int>> ThreeSumBruteForce(List<int> numbers)
        {
            var result = new List<List<int>>();

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    for (int k = 0; k < j; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 0)
                        {
                            result.Add(new List<int> { numbers[i], numbers[j], numbers[k] });
                        }
                    }
                }
            }

            return result;
        }

        private List<List<int>> ThreeSumHashMap(List<int> numbers)
        {
            numbers.Sort();
            var result = new List<List<int>>();

            for (var i = 0; i < numbers.Count; i++)
            {
                TwoSumHashmap(numbers, i, ref result);
            }

            return result;
        }

        private void TwoSumHashmap(List<int> numbers, int index, ref List<List<int>> result)
        {
            var values = new Dictionary<int, int>();
            var target = -numbers[index];
            for (int i = index + 1; i < numbers.Count; i++)
            {
                var number = numbers[i];
                var diff = target - number;                
                if (values.ContainsKey(diff))
                {
                    result.Add(new List<int> { number, diff, numbers[index] });
                }
                values[number] = 1;
            }
        }

        private List<List<int>> ThreeSumIndices(List<int> numbers)
        {
            numbers.Sort();
            var result = new List<List<int>>();

            for (var i = 0; i < numbers.Count; i++)
            {
                TwoSumIndices(numbers, i, ref result);
            }

            return result;
        }

        private void TwoSumIndices(List<int> numbers, int start, ref List<List<int>> result)
        {
            var low = start + 1;
            var high = numbers.Count - 1;

            while (low < high)
            {
                var sum = numbers[start] + numbers[low] + numbers[high];
                if (sum == 0)
                {
                    result.Add(new List<int> { numbers[start], numbers[low], numbers[high] });
                    low++;
                    high--;
                }
                else if (sum < 0)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }
        }
    }
}
